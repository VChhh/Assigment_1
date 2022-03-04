using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shootControl : MonoBehaviour
{
    Rigidbody2D _rb;
    public Camera tranCam;
    private Vector2 mousePos;
    public GameObject player;

    public Vector2 direction;
    private void Start() {
        _rb = GetComponent<Rigidbody2D>();
    }


    private void Update() {
        _rb.position = player.transform.position;

        mousePos = tranCam.ScreenToWorldPoint(Input.mousePosition);
    }


    private void FixedUpdate() {
        

    }
}
