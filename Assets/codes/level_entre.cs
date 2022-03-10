using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class level_entre : MonoBehaviour
{
    public string next_level;
    // Start is called before the first frame update

    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.CompareTag("Player")){
            PublicVars.scores = PublicVars.level1High 
                                + PublicVars.level2High 
                                + PublicVars.level3High 
                                + PublicVars.level4High 
                                + PublicVars.level5High;
            if(PublicVars.cur_level == 5){
                SceneManager.LoadScene("ending");
            }
            SceneManager.LoadScene("Level_" + (PublicVars.cur_level + 1));
        }
    }
}
