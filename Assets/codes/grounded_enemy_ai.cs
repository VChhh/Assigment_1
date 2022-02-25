using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class grounded_enemy_ai : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform _player_tr;
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
        if(!grounded || (Mathf.Abs(_rb.position.y - _player_tr.position.y) <= chase_y_check) && 
          (Vector2.Distance(_rb.position, _player_tr.position) <= chasing_dist)){ 
            float xSpeed = _rb.position.x < _player_tr.position.x ? speed_const : -speed_const;
            _rb.position = new Vector2(_rb.position.x + xSpeed * 0.001f, _rb.position.y);
            if(grounded){
                StartCoroutine(Wait(.5f));
                _rb.AddForce(new Vector2(0, jump_const));
            }
        }
    }

    IEnumerator Wait(float t){
        yield return new WaitForSeconds(t);
    }
    
}
