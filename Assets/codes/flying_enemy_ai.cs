using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flying_enemy_ai : MonoBehaviour
{
    Transform player;
    Rigidbody2D _rb;
    public int chasing_dist = 10;
    public int speed_const = 12;
    public int health = 3;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        _rb = GetComponent<Rigidbody2D>();
        StartCoroutine(moveloop());
    }

    IEnumerator moveloop(){
        while(true){
            yield return new WaitForSeconds(0.1f);

            if(Vector2.Distance(transform.position, player.position) < chasing_dist){

                if( (player.position.x > transform.position.x && transform.localScale.x < 0) || 
                    (player.position.x < transform.position.x && transform.localScale.x > 0)) {
                    transform.localScale *= new Vector2 (-1, 1);
                }

                Vector2 direction = player.position - transform.position;
                _rb.velocity = direction.normalized * speed_const;

            }
        } 
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("bullet")){
            Destroy(other.gameObject);
            if(health == 1){
                Destroy(gameObject);
                PublicVars.cur_level += 100;
            }
            else {
                health--;
            }
        }
    }
}
