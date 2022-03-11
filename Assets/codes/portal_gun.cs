using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class portal_gun : MonoBehaviour
{
    public float gunRange = 1000;
    public GameObject aim_point;
    public GameObject orange_portal_prefab;
    public GameObject blue_portal_prefab;
    private GameObject orange_portal;
    private GameObject blue_portal;

    private bool orange_exist = false;
    private bool blue_exist = false;
    private void Start() {
        aim_point.SetActive(true);
        aim_point.transform.position = GameObject.FindGameObjectWithTag("Player").transform.position;
    }

    private void Update() {
        if(Vector2.Distance(aim_point.transform.position, transform.position) < gunRange){
            if(Input.GetButtonDown("Fire1")){
                if(blue_exist){
                    Destroy(blue_portal);
                }
                blue_portal = Instantiate(blue_portal_prefab, aim_point.transform.position, aim_point.transform.rotation);
                blue_exist = true;
                if(orange_exist && blue_exist){
                    //blue_portal.GetComponent<portal>().get_dst();
                    //orange_portal.GetComponent<portal>().get_dst();
                }

            }
            if(Input.GetButtonDown("Fire2")){
                if(orange_exist){
                    Destroy(orange_portal);
                }
                orange_portal = Instantiate(orange_portal_prefab, aim_point.transform.position, aim_point.transform.rotation);
                orange_exist = true;
                if(orange_exist && blue_exist){
                    //blue_portal.GetComponent<portal>().get_dst();
                    //orange_portal.GetComponent<portal>().get_dst();
                }
                
            }
        }
    }


}
