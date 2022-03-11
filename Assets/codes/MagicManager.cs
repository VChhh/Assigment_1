using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicManager : MonoBehaviour
{
    private AudioSource audioSrc;
    void Start()
    {
        audioSrc = GetComponent<AudioSource> ();
    }

    void Update()
    {
        //magic want attack sound when leftclicking mouse
        if(Input.GetButtonDown("Fire1")){
            audioSrc.Play();
        }
    }
}
