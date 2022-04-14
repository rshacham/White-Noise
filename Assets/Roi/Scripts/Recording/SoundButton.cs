
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class SoundButton : MonoBehaviour
{
    private AudioClip mySound;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void LoadSound(String path)
    {
        WWW audioLoader = new WWW(path);
        while (!audioLoader.isDone)
        {
            Debug.Log("uploading");
        }
 
        Debug.Log("1");
        
    }
}
