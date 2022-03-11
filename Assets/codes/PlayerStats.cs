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
        if(PublicVars.cur_level >= 3){
            PublicVars.dashable = true;
        }
        if(transform.Find("hand").Find("wand")){
            PublicVars.shootable = true;
        }
        if(transform.Find("hand").Find("portalGun")){
            PublicVars.shootable = false;
            PublicVars.portable = true;
        }
    }

    void display(){
        string high = "";
        //store current score
        if(PublicVars.cur_level == 1 && PublicVars.cur_score > PublicVars.level1High)
            PublicVars.level1High = PublicVars.cur_score;
        else if(PublicVars.cur_level == 2 && PublicVars.cur_score > PublicVars.level2High)
            PublicVars.level2High = PublicVars.cur_score;
        else if(PublicVars.cur_level == 3 && PublicVars.cur_score > PublicVars.level3High)
            PublicVars.level3High = PublicVars.cur_score;
        else if(PublicVars.cur_level == 4 && PublicVars.cur_score > PublicVars.level4High)
            PublicVars.level4High = PublicVars.cur_score;
        else if(PublicVars.cur_level == 5 && PublicVars.cur_score > PublicVars.level5High)
            PublicVars.level5High = PublicVars.cur_score;
        
        //change display info
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


        //display
        playStats.text = "Level " + PublicVars.cur_level
                        + "\ncur_score: " + PublicVars.cur_score
                        + high;
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("gem")){
            PublicVars.cur_score += 100;
            Destroy(other.gameObject);
            display();
        }
        else if(other.CompareTag("b_gem")){
            PublicVars.cur_score += 300;
            Destroy(other.gameObject);
            display();
        }

    }


    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.CompareTag("trap")){
            PublicVars.cur_score -= 300;
            transform.position = PublicVars.checkPoint;
            display();
        }
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        
    
        //syn the level number
        PublicVars.cur_level = SceneManager.GetActiveScene().name[6] - '0';


            
    }
}
