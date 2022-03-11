using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicManager : MonoBehaviour
{
    // Start is called before the first frame update
    private AudioSource audioSrc;
    void Start()
    {
        audioSrc = GetComponent<AudioSource> ();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1")){
            audioSrc.Play();
        }
    }
}
