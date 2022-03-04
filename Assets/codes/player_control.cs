using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class player_control : MonoBehaviour
{
    bool isAlive = true;
    public int speed_const = 10;
    public int jump_const = 500;
    //===========grab============
    public Transform hand;

    //============dash================
    public float dash_force;
    private float origin_dash_time;
    public float dash_time;
    private float origin_cooldown;
    public float dash_cooldown = 1;
    private int dash_limit = 1;


    //============shoot=================
    public bool shootable = true;
    public GameObject bulletPrefab;
    public float bulletSpd = 20f;

    // public Camera cam;
    // private Vector2 mousePos;
    // public Vector2 shoot_direction;

    public float shoot_cool = 1;




    //===========================
    Rigidbody2D _rb;
    Animator _at;
    public LayerMask ground;
    public Transform feet;
    float ground_check_dist = .2f;
    public bool grounded = false;
    public bool dashing = false;
    public bool dashable = false;

    private float direction;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _at = GetComponent<Animator>();
        origin_dash_time = dash_time;
        origin_cooldown = dash_cooldown;
    }

    private void FixedUpdate() {
        grounded = Physics2D.OverlapCircle(feet.position, ground_check_dist, ground); // check if grounded
        _at.SetBool("Grounded", grounded);  
        // shoot_direction = -(mousePos - _rb.position);
        //angle = Mathf.Atan2(shoot_direction.y, shoot_direction.x) * Mathf.Rad2Deg - 90f;


        if(Input.GetKeyDown("e") && shootable){
            hand.gameObject.transform.GetChild(0).parent = null;
            shootable = false;
        }
        else if(Input.GetKeyDown("q") && dashable){
            feet.gameObject.transform.GetChild(0).parent = null;
            dashable = false;
        }
    }


    private void OnTriggerStay2D(Collider2D other) {
        //grab
        if(other.CompareTag("wand") && Input.GetKeyDown("e")){
            other.gameObject.transform.position = hand.position;
            other.gameObject.transform.parent = hand;
            shootable = true;
        }
        else if(other.CompareTag("boot") && Input.GetKeyDown("q")){
            other.gameObject.transform.position = feet.position;
            other.gameObject.transform.parent = feet;
            dashable = true;
        }
        else if(other.CompareTag("key") && Input.GetKeyDown("e")){
            other.gameObject.transform.position = hand.position;
            other.gameObject.transform.parent = hand;
        }
    }
    void Update()
    {
        // mousePos = cam.ScreenToViewportPoint(Input.mousePosition);


        if (isAlive && transform.position.y < -100)
        {
            isAlive = false;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        // horizontal movement
        float xSpeed = Input.GetAxis("Horizontal") * speed_const;
        _rb.velocity = new Vector2(xSpeed, _rb.velocity.y);
        _at.SetFloat("Speed", Mathf.Abs(xSpeed));

        // jumping
        if(grounded && Input.GetButtonDown("Jump")){
            _rb.AddForce(new Vector2(0, jump_const));
        }

        if(xSpeed > 0 && transform.localScale.x > 0 || xSpeed < 0 && transform.localScale.x < 0){
            transform.localScale *= new Vector2(-1, 1);
        }

        // dash
        if(dashable){
            if(dashing)
            {
                _rb.velocity = transform.right * direction * dash_force;
                dash_time -= Time.deltaTime;
                if(grounded){
                    dash_limit = 1;
                }
                if(dash_time <= 0){
                    dashing = false;
                }
            }//dashing
            else if(!dashing && dash_cooldown > 0){
                dash_cooldown -= Time.deltaTime;
            }//cooldown
            else if(grounded){
                dash_limit = 1;
            }
            else if(Input.GetKeyDown("left shift") && xSpeed != 0 && dash_limit == 1){
                dashing = true;
                dash_limit = 0;
                dash_cooldown = origin_cooldown;
                dash_time = origin_dash_time;
                _rb.velocity = Vector2.zero;
                direction = (int)xSpeed;
            }//start to dash
        }



    //shoot
        if(shootable){
            if(shoot_cool > 0){
                shoot_cool -= Time.deltaTime;
            }
            else if(Input.GetButtonDown("Fire1")){
                shoot_cool = 1;
                GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
                bullet.GetComponent<Rigidbody2D>().AddForce(new Vector2(bulletSpd * -transform.localScale.x, 0));
            }
        }


    }



}
