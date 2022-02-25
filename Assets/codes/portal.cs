using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class portal : MonoBehaviour
{
    // still testing, not complete yet
    // will complete next week
    public GameObject dst;
    bool is_overlapping = false;
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Player") && !is_overlapping){
            other.transform.position = dst.transform.position;
            is_overlapping = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        is_overlapping = false;
    }

}
