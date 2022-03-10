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
            SceneManager.LoadScene("Level_" + (PublicVars.cur_level + 1));
        }
    }
}
