using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class aiming : MonoBehaviour
{
   public float x_const = 0.3f;
   public float y_const = 0.25f;
   private Vector2 boundary;
   private void Start() {
       
   }

   private void Update() {
       float _horizontal = Input.GetAxis("Mouse X") + Input.GetAxis("Right Stick X")*0.08f;
       float _vertical = Input.GetAxis("Mouse Y") - Input.GetAxis("Right Stick Y")*0.08f;
       transform.position = new Vector2(transform.position.x + x_const * _horizontal, transform.position.y + y_const * _vertical);
   }

   
}
