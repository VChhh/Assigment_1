using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flying_enemy_ai : MonoBehaviour
{
    public Rigidbody2D _player_rb;
    Rigidbody2D _rb;
    public int chasing_dist = 10;
    public int speed_const = 12;
    public int jump_const = 400;
    private float chase_y_check = .8f;
    public LayerMask ground;
    public Transform feet;
    float ground_check_dist = .2f;
    bool grounded = false;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void FixedUpdate() {
        grounded = Physics2D.OverlapCircle(feet.position, ground_check_dist, ground);
    }
    void Update()
    {
        if(Vector2.Distance(_rb.position, _player_rb.position) <= chasing_dist){ 
            Vector2 direction = _player_rb.position - _rb.position;
            direction.Normalize();
            _rb.velocity = direction * speed_const;
        }
        if(grounded){
            _rb.AddForce(new Vector2(0, jump_const));
            // StartCoroutine(Wait(2f)); // use wait to adjust the shaking when grounded
        }
    }

    IEnumerator Wait(float t){
        yield return new WaitForSeconds(t);
    }
}
