
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using Image = UnityEngine.UIElements.Image;

public class SoundButton : MonoBehaviour
{
    public AudioClip mySound;
    public Slider pitchSlider;
    [SerializeField] public AudioSource soundSource;
    public Slider volumeSlider;
    public Slider trimSlider;
    public Button looperButton;
    private Coroutine myLooper;
    public int looperCounter;
    public LoopButton loopButton;

    public RectTransform loopMarkTransform;
    [SerializeField] private List<float> markRotations;

    public float soundPitch = 1; // We need to associate this with a slider, boundaries between 0.2 and 3?


    void Start()
    {
        Vector3 a = loopMarkTransform.eulerAngles;
        loopMarkTransform.eulerAngles = new Vector3(a.x, a.y, markRotations[0]);
    }
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
            Debug.Log("uploading");
        }
 
        mySound = audioLoader.GetAudioClip();
        soundSource.clip = mySound;
    }

    public void PlaySoundOneTime()
    {
        if (mySound != null)
        {
            SoundManager._shared.PlayOuterSoundOneTime(soundSource, mySound);
        }
        
        else
        {
            print("hey");
        }
    }

    public void ChangeLooper()
    {
        looperCounter++;
        Vector3 markRotation = loopMarkTransform.eulerAngles;
        loopMarkTransform.eulerAngles = new Vector3(markRotation.x, markRotation.y, markRotations[looperCounter % 4]);
        
        if (soundSource.clip == null || !loopButton.isOn)
        {
            return;
        }

        if (myLooper == null)
        {
            SoundManager._shared.loopSound = true;
            myLooper = SoundManager._shared.StartLooper(soundSource, soundSource.clip, looperCounter % 4);
        }

        else
        {
            SoundManager._shared.loopSound = true;
            SoundManager._shared.LooperEnumerators[soundSource] = SoundManager._shared.mySpeeds[looperCounter % 4];
        }
    }

    public void StopLooper()
    {
        if (!loopButton.isOn)
        {
            SoundManager._shared.LooperEnumerators[soundSource] = 100;
        }
    }
    
}
