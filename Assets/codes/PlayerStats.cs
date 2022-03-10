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
        PublicVars.cur_level = SceneManager.GetActiveScene().name[6] - '0';
        display();
        PublicVars.checkPoint = transform.position;
    }

    void display(){
        string high = "";
        if(PublicVars.cur_level == 1)
            high = "\nhighest score for level 1: " + PublicVars.level1High;
        else if(PublicVars.cur_level == 2)
            high = "\nhighest score for level 2: " + PublicVars.level2High;
        else if(PublicVars.cur_level == 3)
            high = "\nhighest score for level 3: " + PublicVars.level3High;
        else if(PublicVars.cur_level == 4)
            high = "\nhighest score for level 4: " + PublicVars.level4High;
        else if(PublicVars.cur_level == 5)
            high = "\nhighest score for level 5: " + PublicVars.level5High;

        
        playStats.text = "Level " + PublicVars.cur_level
                        + "\nCoins: " + PublicVars.coins 
                        + "\nScores: " + PublicVars.scores
                        + high;
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
        PublicVars.cur_level = SceneManager.GetActiveScene().name[6] - '0';
    }
}
