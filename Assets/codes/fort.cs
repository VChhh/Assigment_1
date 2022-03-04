using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fort : MonoBehaviour
{
    // Start is called before the first frame update
    public bool shootable = true;
    public GameObject bulletPrefab;
    public float bulletSpd = 20f;

    // Update is called once per frame
    void Update()
    {
        if(shootable){
            GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
            bullet.GetComponent<Rigidbody2D>().AddForce(new Vector2(bulletSpd * -transform.localScale.x, 0));
        }
    }
}
