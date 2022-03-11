using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class portal : MonoBehaviour
{
    public bool is_orange;
    public float teleport_dist = 0.1f;
    public Transform dst;
    private bool is_teleported = false;
    private void Start() {
        if(is_orange){
            dst = GameObject.FindGameObjectWithTag("blue_portal").GetComponent<Transform>();
        } else {
            dst = GameObject.FindGameObjectWithTag("orange_portal").GetComponent<Transform>();
        }
        dst.gameObject.GetComponent<portal>().dst = transform;
    }

    private void OnTriggerEnter2D(Collider2D other) {
        print("hahaha");
        print(Vector2.Distance(transform.position, other.transform.position));
        if((!is_teleported) && Vector2.Distance(transform.position, other.transform.position) > teleport_dist){
            print("tttt");
            is_teleported = true;
            other.transform.position = new Vector2(dst.position.x, dst.position.y);
        }
        
    }

    private void OnTriggerExit2D(Collider2D other) {
        is_teleported = false;
    }

    public void get_dst(){
        if(is_orange){
            dst = GameObject.FindGameObjectWithTag("blue_portal").GetComponent<Transform>();
        } else {
            dst = GameObject.FindGameObjectWithTag("orange_portal").GetComponent<Transform>();
        }
    }

}
