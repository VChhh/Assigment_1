using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ending_menu : MonoBehaviour
{
    public void quits(){
        Time.timeScale = 1;
        SceneManager.LoadScene("title");
    }
}
