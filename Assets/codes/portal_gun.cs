using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class portal_gun : MonoBehaviour
{
    public float gunRange = 1000;
    private portal[] portals;

    void Start()
    {
        portals = GameObject.FindObjectsOfType<portal>();
        if(portals.Length != 2){
            Debug.LogError("portals not attached");
        }
    }


    void Update()
    {
        if(Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1)){
            Vector2 position = Input.mousePosition;
            RaycastHit2D hit = new RaycastHit2D();
            if(Physics2D.Linecast(transform.position, position * gunRange, 1)){

            }
        }
    }
}
