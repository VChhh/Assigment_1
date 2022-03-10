using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ladder_movement : MonoBehaviour
{
    public float climb_const = 1;
    public int climb_jump_const = 300;
    private float climb_speed;
    private bool is_ladder = false;
    private bool is_climbing = false;
    private float initial_grav;
    Rigidbody2D _rb;

    private void Start() {
        _rb=GetComponent<Rigidbody2D>();
        initial_grav = _rb.gravityScale;
    }

    void Update()
    {
        if(is_climbing){
            _rb.gravityScale = 0;
            _rb.velocity = new Vector2(_rb.velocity.x, climb_speed * climb_const);
        }
        else{
            _rb.gravityScale = initial_grav;
        }
        climb_speed = Input.GetAxis("Vertical");
        if(Mathf.Abs(climb_speed) > 0f && is_ladder){
            is_climbing = true;
            _rb.AddForce(new Vector2(0, climb_speed*climb_speed));
        }

        // climb jump
        // unexpeted behavior, disabled for this version
        // could be improved
        /*
        if(!GetComponent<player_control>().grounded && is_climbing && Input.GetButtonDown("Jump")){
            is_climbing = false;
            _rb.gravityScale = initial_grav;
            _rb.velocity = new Vector2(_rb.velocity.x, 0);
            _rb.AddForce(new Vector2(0, climb_jump_const));
            
        }
        */
    }
        private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("ladder")){
            is_ladder = true;
            
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if(other.CompareTag("ladder")){
            is_ladder = false;
            is_climbing = false;
        }
    }

    IEnumerator ladder_jump(){
        
        yield return new WaitForSeconds(0.5f);
    }
}
