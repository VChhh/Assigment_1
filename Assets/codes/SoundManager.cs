using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpManager : MonoBehaviour
{   
    //public static AudioClip playerShoot, playerJump; 
    private AudioSource audioSrc;
    void Start()
    {
        audioSrc = GetComponent<AudioSource> ();
    }

    void Update()
    {
        if(Input.GetButtonDown("Jump") || Input.GetKeyDown(KeyCode.Space)){
            audioSrc.Play();
        }
    }
}
