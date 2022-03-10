using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class PlayerStats : MonoBehaviour
{

    public TextMeshProUGUI playStats;


    public LayerMask killable; // What layers can be grabbed

    private float raycastDist = 3;

    void Start()
    {
        display();
        PublicVars.checkPoint = transform.position;
    }

    void display(){
        playStats.text = "Level " + PublicVars.cur_level
                        + "\nCoins: " + PublicVars.coins 
                        + "\nScores: " + PublicVars.scores;
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("collectibles")){
            PublicVars.coins ++;
            PublicVars.scores += 100;
            Destroy(other.gameObject);
            display();
        }
        else if(other.CompareTag("hidden")){
            PublicVars.coins -= 50;
            PublicVars.scores += 150;
            display();
        }
    }


    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.CompareTag("trap")){
            PublicVars.scores -= 300;
            transform.position = PublicVars.checkPoint;
        }
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        
    }
}
