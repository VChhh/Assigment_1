using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pause_menu : MonoBehaviour
{
    public static bool is_paused = false;
    public GameObject pausemenuIU;
    public GameObject level_selector_menu;

    private void Update() {
        if(Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.JoystickButton1)){
            if(is_paused){
                Resume();
            }
            else{
                Pause();
            }
        }
    }

    public void Resume() {
        pausemenuIU.SetActive(false);
        level_selector_menu.SetActive(false);
        Time.timeScale = 1f;
        is_paused = false;
        Cursor.visible = false;
    }

    public void Pause() {
        pausemenuIU.SetActive(true);
        Time.timeScale = 0f;
        is_paused = true;
    }

    public void tutorial(){
        Debug.Log("tutorial=====");
    }

    public void levels(){
        level_selector_menu.SetActive(true);
    }

    public void quits(){
        Time.timeScale = 1;
        SceneManager.LoadScene("title");
    }

    public void level_selector(string name){
        Time.timeScale = 1;
        SceneManager.LoadScene(name);
    }
}
