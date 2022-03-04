using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_control : MonoBehaviour
{
    public int speed_const = 10;
    public int jump_const = 500;
    public float dash_force;
    private float origin_dash_time;
    public float dash_time;
    private float origin_cooldown;
    public float dash_cooldown = 1;
    private int dash_limit = 1;

    private Vector2 mousePos;

    public Camera tranCam;
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

        Vector2 lookDirection = mousePos - _rb.position;
        float angle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg - 90f;
    }



    void Update()
    {
        mousePos = tranCam.ScreenToWorldPoint(Input.mousePosition);

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
    }



}
