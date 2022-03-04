using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class portal : MonoBehaviour
{
    public bool is_orange;
    public float teleport_dist = 0.2f;
    Transform dst;
    public bool able_to_teleport = false;
    private void Start() {

        //get_dst();
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(Vector2.Distance(transform.position, other.transform.position) > teleport_dist){
            other.transform.position = new Vector2(dst.position.x, dst.position.y);
        }
    }

    public void get_dst(){
        if(is_orange){
            try{
                dst = GameObject.FindGameObjectWithTag("blue_portal").GetComponent<Transform>();
            }
            catch{}
        } else {
            try{
                dst = GameObject.FindGameObjectWithTag("orange_portal").GetComponent<Transform>();
            }
            catch{}
        }
    }

}
