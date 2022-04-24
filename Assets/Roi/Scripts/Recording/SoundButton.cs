
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
    private Coroutine myLooper;
    public int looperCounter;
    public LoopButton loopButton;

    public RectTransform loopMarkTransform;
    [SerializeField] private List<float> markRotations;

    [SerializeField] public Color fadeColor;
    [SerializeField] private List<GameObject> buttonsObjects;

    [SerializeField] private List<Slider> unitSliders;
    [SerializeField] private List<Button> unitButtons;
    [SerializeField] public float recordDelay;


    void Start()
    {
        Vector3 a = loopMarkTransform.eulerAngles;
        loopMarkTransform.eulerAngles = new Vector3(a.x, a.y, markRotations[0]);
        TurnButtons(false);

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
            // Debug.Log("uploading");
        }
        
        // Debug.Log("1");

        mySound = audioLoader.GetAudioClip();
        soundSource.clip = mySound;
    }

    public void PlaySoundOneTime()
    {
        if (soundSource.isPlaying)
        {
            soundSource.Stop();
        }
        if (soundSource.clip != null)
        {
            soundSource.time = recordDelay;
            soundSource.Play();
        }
        // if (mySound != null)
        // {
        //     SoundManager._shared.PlayOuterSoundOneTime(soundSource, mySound);
        // }
        //
        // else
        // {
        //     // print("hey");
        // }
    }

    public void ChangeLooper()
    {
        looperCounter++;
        Vector3 markRotation = loopMarkTransform.eulerAngles;
        loopMarkTransform.eulerAngles = new Vector3(markRotation.x, markRotation.y, markRotations[looperCounter % markRotations.Count]);
        
        if (soundSource.clip == null || !loopButton.isOn)
        {
            return;
        }

        if (myLooper == null)
        {
            SoundManager._shared.loopSound = true;
            myLooper = SoundManager._shared.StartLooper(this, soundSource, soundSource.clip, looperCounter % markRotations.Count);
        }

        else
        {
            SoundManager._shared.loopSound = true;
            SoundManager._shared.LooperEnumerators[soundSource] = SoundManager._shared.mySpeeds[looperCounter % markRotations.Count];
        }
    }

    public void StopLooper()
    {
        if (!loopButton.isOn)
        {
            SoundManager._shared.LooperEnumerators[soundSource] = 100;
        }
    }

    public void TurnButtons(bool state)
    {
        foreach (var button in unitButtons)
        {
            button.enabled = state;
        }
        
        foreach (var slider in unitSliders)
        {
            slider.enabled = state;
        }
    }
    
    
    
}
