using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gate : MonoBehaviour
{

    public string color;

    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.CompareTag("Player")){
            if(other.transform.Find("back").Find(color)){
                Destroy(other.transform.Find("back").Find(color).gameObject);
                Destroy(transform.gameObject);
            }
        }
    }
}
