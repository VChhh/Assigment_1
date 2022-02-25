// will improved by loading a canvas with resume, tutorial, option, back_to_start_menu, and quit game buttons
// when pressing the KeyCode.Escape
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class quit_check : MonoBehaviour
{
    private void Awake() {
        // check number of object with class quit_check
        if(FindObjectsOfType<quit_check>().Length > 1){
            Destroy(gameObject);
        }
        else {
            DontDestroyOnLoad(gameObject);
        }
    }
    private void Update() {
        if(Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.JoystickButton1)){
            SceneManager.LoadScene("title");
        }
    }
}
