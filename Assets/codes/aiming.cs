using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class aiming : MonoBehaviour
{
   public Transform _player;
   public float x_const = 0.3f;
   public float y_const = 0.25f;
   private void Start() {
       transform.position = _player.position;
   }

   private void Update() {
       float _horizontal = Input.GetAxis("Mouse X");
       float _vertical = Input.GetAxis("Mouse Y");
       transform.position = new Vector2(transform.position.x + x_const * _horizontal, transform.position.y + y_const * _vertical);
   }
}
