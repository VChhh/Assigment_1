using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shoot : MonoBehaviour

{
    public bool shootable = true;
    public GameObject bulletPrefab;
    public Transform firePos;
    public float bulletSpd = 20f;

    // Update is called once per frame
    void Update()
    {
        
        //shoot
        if(shootable){
            if(Input.GetButtonDown("Fire1")){
                GameObject bullet = Instantiate(bulletPrefab, firePos.position, firePos.rotation);
                Rigidbody2D _rb = bullet.GetComponent<Rigidbody2D>();
                _rb.AddForce(firePos.right * bulletSpd, ForceMode2D.Impulse);
            }
        }
    }
}
