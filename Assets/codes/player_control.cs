using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_control : MonoBehaviour
{
    public int speed_const = 10;
    public int jump_const = 500;
    Rigidbody2D _rb;
    public LayerMask ground;
    public Transform feet;
    float ground_check_dist = .2f;
    bool grounded = false;
    
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate() {
        grounded = Physics2D.OverlapCircle(feet.position, ground_check_dist, ground); // check if grounded
    }

    void Update()
    {
        // horizontal movement
        float xSpeed = Input.GetAxis("Horizontal") * speed_const;
        _rb.velocity = new Vector2(xSpeed, _rb.velocity.y);

        // jumping
        if(grounded && Input.GetButtonDown("Jump")){
            _rb.AddForce(new Vector2(0, jump_const));
        }
    }
}
