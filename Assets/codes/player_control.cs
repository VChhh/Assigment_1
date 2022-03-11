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
    public Transform back;

    //============dash================
    public float dash_force;
    private float origin_dash_time;
    public float dash_time;
    private float origin_cooldown;
    public float dash_cooldown = 1;
    private int dash_limit = 1;


    //============shoot=================
    public GameObject bulletPrefab;
    public float bulletSpd = 20f;

    public Transform handPos;

    // public Camera cam;
    // private Vector2 mousePos;
    // public Vector2 shoot_direction;

    public float shoot_cool = 0.8f;
    private float origin_shootcool;

    //===========================
    Rigidbody2D _rb;
    Animator _at;
    public LayerMask ground;
    public Transform feet;
    float ground_check_dist = .2f;
    public bool grounded = false;
    public bool dashing = false;

    private float direction;

    void Start()
    {
        Cursor.visible = false;
        _rb = GetComponent<Rigidbody2D>();
        _at = GetComponent<Animator>();
        _at.SetBool("dashable", false);
        _at.SetBool("shootable", false);
        origin_dash_time = dash_time;
        origin_cooldown = dash_cooldown;
        origin_shootcool = shoot_cool;
    }

    private void FixedUpdate() {
        grounded = Physics2D.OverlapCircle(feet.position, ground_check_dist, ground); // check if grounded
        _at.SetBool("Grounded", grounded);  
        // shoot_direction = -(mousePos - _rb.position);
        //angle = Mathf.Atan2(shoot_direction.y, shoot_direction.x) * Mathf.Rad2Deg - 90f;


        if(PublicVars.shootable){
            _at.SetBool("shootable", true);
        }
        if(PublicVars.dashable){
            _at.SetBool("dashable", true);
        }
    }


    private void OnTriggerStay2D(Collider2D other) {
        //grab
        if(other.CompareTag("wand") && Input.GetButtonDown("Grab")){
            other.gameObject.transform.position = hand.position;
            other.gameObject.transform.parent = hand;
            PublicVars.shootable = true;
        }
        if(other.CompareTag("boot") && Input.GetButtonDown("Grab")){
            // other.gameObject.transform.position = feet.position;
            // other.gameObject.transform.parent = feet;
            PublicVars.dashable = true;
            _at.SetBool("dashable", true);
            Destroy(other.gameObject);
        }
        if(other.CompareTag("key") && Input.GetButtonDown("Grab")){
            other.gameObject.transform.position = back.position;
            other.gameObject.transform.parent = back;
        }
        if(other.CompareTag("portalGun") && Input.GetButtonDown("Grab")){
            other.gameObject.transform.position = hand.position;
            other.gameObject.transform.parent = hand;
        }

    }


    void Update()
    {
        // mousePos = cam.ScreenToViewportPoint(Input.mousePosition);


        // if (isAlive && transform.position.y < -100)
        // {
        //     isAlive = false;
        //     SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        // }

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
        if(PublicVars.dashable){
            if(dashing)
            {
                _at.SetBool("dashing", true);
                _rb.velocity = transform.right * direction * dash_force;
                dash_time -= Time.deltaTime;
                if(grounded){
                    dash_limit = 1;
                }
                if(dash_time <= 0){
                    dashing = false;
                    _at.SetBool("dashing", false);
                }
            }//dashing
            else if(!dashing && dash_cooldown > 0){
                dash_cooldown -= Time.deltaTime;
            }//cooldown
            else if(grounded){
                dash_limit = 1;
            }
            else if(Input.GetButtonDown("Dash") && xSpeed != 0 && dash_limit == 1){
                dashing = true;
                dash_limit = 0;
                dash_cooldown = origin_cooldown;
                dash_time = origin_dash_time;
                _rb.velocity = Vector2.zero;
                direction = (int)xSpeed;
            }//start to dash
        }



    //shoot
        if(PublicVars.shootable){
            if(shoot_cool > 0){
                shoot_cool -= Time.deltaTime;
            }
            else if(Input.GetButtonDown("Fire1")){
                shoot_cool = origin_shootcool;
                GameObject bullet = Instantiate(bulletPrefab, handPos.position, Quaternion.identity);
                bullet.GetComponent<Rigidbody2D>().AddForce(new Vector2(bulletSpd * -transform.localScale.x, 0));

                Destroy(bullet, 3f);

            }
        }

    
    }



}
