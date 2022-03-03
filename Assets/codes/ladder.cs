using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ladder : MonoBehaviour
{
    // ladder code for climbing
    // imcomplete version, use ladder_movement which attaches to player instead
    public int ladder_jump_const = 300;
    public float climbing_const = 0.01f;
    private float initial_grav = 1;
    private bool is_player = false;
    private bool player_present = false;
    private bool is_on_ladder = false;
    Transform _player_tr;
    Rigidbody2D _player_rb;
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Player")){
            is_player = true;
            player_present = true;
            _player_tr = other.GetComponent<Transform>();
            _player_rb = other.GetComponent<Rigidbody2D>();
            initial_grav = _player_rb.gravityScale;
        }
    }

    private void Update() {
        if(!is_on_ladder){
            //_player_rb.gravityScale = initial_grav;
        }
        if(is_player && player_present && Input.GetAxis("Vertical") != 0){
            if(!is_on_ladder){
                _player_rb.velocity = new Vector2(0,0);
            }
            //_player_rb.gravityScale = 0;
            is_on_ladder = true;
            _player_tr.position = new Vector2(_player_tr.position.x, 
                                 _player_tr.position.y + Input.GetAxis("Vertical") * climbing_const);
        }
        if(is_on_ladder && Input.GetButtonDown("Jump")){
            is_on_ladder = false;
            _player_rb.AddForce(new Vector2(0, ladder_jump_const));
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if(other.CompareTag("Player")){
            is_player = false;
            player_present = false;
            is_on_ladder = false;
        }
    }
}
