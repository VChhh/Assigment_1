using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class end : MonoBehaviour
{
    public TextMeshProUGUI endStats;

    void display(){
        string text;
        text =  "Total Score: " + PublicVars.scores
                + "\nHighest Score for Lv_1: " + PublicVars.level1High
                + "\nHighest Score for Lv_2: " + PublicVars.level2High
                + "\nHighest Score for Lv_3: " + PublicVars.level3High
                + "\nHighest Score for Lv_4: " + PublicVars.level4High
                + "\nHighest Score for Lv_5: " + PublicVars.level5High;

        endStats.text = text;
    }

    private void Start() {
        display();
    }


}
