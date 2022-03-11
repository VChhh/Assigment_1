using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class aiming : MonoBehaviour
{
   public float x_const = 0.3f;
   public float y_const = 0.25f;
   private Vector2 boundary;
   private void Start() {
       boundary = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height));
   }

   private void Update() {
       float _horizontal = Input.GetAxis("Mouse X") + Input.GetAxis("Right Stick X")*0.08f;
       float _vertical = Input.GetAxis("Mouse Y") - Input.GetAxis("Right Stick Y")*0.08f;
       transform.position = new Vector2(transform.position.x + x_const * _horizontal, transform.position.y + y_const * _vertical);
   }

   private void LateUpdate() {
        Vector2 viewpos = transform.position;
        viewpos.x = Mathf.Clamp(viewpos.x, boundary.x, boundary.x* -1);
        viewpos.y = Mathf.Clamp(viewpos.y, boundary.y, boundary.y* -1);
        transform.position = viewpos;
   }
}
