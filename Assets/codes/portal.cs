using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class portal : MonoBehaviour
{
    public bool is_orange;
    public float teleport_dist = 0.3f;
    public Transform dst;
    private void Start() {
        if(is_orange){
            dst = GameObject.FindGameObjectWithTag("blue_portal").GetComponent<Transform>();
        } else {
            dst = GameObject.FindGameObjectWithTag("orange_portal").GetComponent<Transform>();
        }
        dst.gameObject.GetComponent<portal>().dst = transform;
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(Vector2.Distance(transform.position, other.transform.position) > teleport_dist){

            other.transform.position = new Vector2(dst.position.x, dst.position.y);

        }
    }

    public void get_dst(){
        if(is_orange){
            dst = GameObject.FindGameObjectWithTag("blue_portal").GetComponent<Transform>();
        } else {
            dst = GameObject.FindGameObjectWithTag("orange_portal").GetComponent<Transform>();
        }
    }

}
