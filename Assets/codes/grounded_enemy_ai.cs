using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class grounded_enemy_ai : MonoBehaviour
{
    Transform player;
    Rigidbody2D _rb;

    public Transform feet;
    public int chasing_dist = 10;
    public int speed_const = 12;
    public int jump_const = 100;

    // ============================
    public LayerMask ground;
    float ground_check_dist = .2f;
    public bool grounded = false;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        _rb = GetComponent<Rigidbody2D>();
        StartCoroutine(moveloop());
    }
    private void FixedUpdate() {
        Vector2 temp = new Vector2(transform.position.x, feet.position.y);
        grounded = Physics2D.OverlapCircle(temp, ground_check_dist, ground);
    }
    private void Update() {
        if( (player.position.x > transform.position.x && transform.localScale.x > 0) || 
            (player.position.x < transform.position.x && transform.localScale.x < 0)) {
                transform.localScale *= new Vector2 (-1, 1);
        }
    }
    IEnumerator moveloop(){
        while(true){
            yield return new WaitForSeconds(Random.Range(0.4f, 0.6f));
            
            if(Vector2.Distance(transform.position, player.position) < chasing_dist) {
                if(grounded){
                    _rb.AddForce(new Vector2(0 , jump_const));
                }
                _rb.AddForce(new Vector2(-transform.localScale.x * speed_const, 0));
            }
        } 
    }
}
