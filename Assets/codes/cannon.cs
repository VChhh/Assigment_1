using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cannon : MonoBehaviour
{

    public bool shootable = true;
    public GameObject bulletPrefab;
    public float bulletSpd = 20f;
    public float cooldown = 1.5f;

    public float destroy_time = 2;

    private void Start() {
        StartCoroutine(fire());
    }
    IEnumerator fire(){
        while(true){
            yield return new WaitForSeconds(cooldown);

            GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
            bullet.GetComponent<Rigidbody2D>().AddForce(transform.right * bulletSpd, ForceMode2D.Impulse);
            Destroy(bullet.gameObject, destroy_time);

        }

    }
}
