
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class SoundButton : MonoBehaviour
{
    public AudioClip mySound;
    public Slider pitchSlider;
    [SerializeField] AudioSource soundSource;
    public Slider volumeSlider;

    public float soundPitch = 1; // We need to associate this with a slider, boundaries between 0.2 and 3?


    public void Update()
    {
        soundSource.volume = volumeSlider.value;
        soundSource.pitch = pitchSlider.value;
    }

    public void LoadSound(String path)
    {
        var audioLoader = new WWW(path + ".wav");
        while (!audioLoader.isDone)
        {
            // Debug.Log("uploading");
        }
 
        // Debug.Log("1");
        mySound = audioLoader.GetAudioClip();
    }

    public void PlaySoundOneTime()
    {
        if (mySound != null)
        {
            SoundManager._shared.PlayOuterSoundOneTime(soundSource, mySound);
            //SoundManager._shared.mySource.pitch = 1;
        }
        else
        {
            // print("hey");
        }
    }
}
