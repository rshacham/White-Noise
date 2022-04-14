
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

    public void LoadSound(String path)
    {
        var audioLoader = new WWW(path + ".wav");
        while (!audioLoader.isDone)
        {
            Debug.Log("uploading");
        }
 
        Debug.Log("1");
        mySound = audioLoader.GetAudioClip();
    }

    public void PlaySoundOneTime()
    {
        if (mySound != null)
        {
            print(mySound.length);
            SoundManager._shared.PlayOuterSoundOneTime(mySound);
        }
        else
        {
            print("hey");
        }
    }
}
