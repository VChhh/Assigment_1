using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class portal : MonoBehaviour
{
    public bool is_orange;
    public float teleport_dist = 0.2f;
    public float b_teleport_dist = 0.1f;
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
        float dis = Mathf.Abs(transform.position.x - other.transform.position.x) * 2;
        print(dis);
        //if(dis < teleport_dist){
        //    other.transform.position = new Vector2(dst.position.x, dst.position.y);
        //}
        if(Vector2.Distance(transform.position, other.transform.position) > teleport_dist || 
            (dis > b_teleport_dist && 
                (other.CompareTag("bullet") || other.CompareTag("cannon_bullet")))){
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
