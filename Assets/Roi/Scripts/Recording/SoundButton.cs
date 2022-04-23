
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
    // [SerializeField] private Image looperSpeedImage;
    // [SerializeField] private List<Sprite> looperSpeedSprites;

    [SerializeField] private List<GameObject> buttonsObjects;
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
            // Debug.Log("uploading");
        }
        
        // Debug.Log("1");

        mySound = audioLoader.GetAudioClip();
        soundSource.clip = mySound;
    }

    public void PlaySoundOneTime()
    {
        if (soundSource.clip != null)
        {
            soundSource.PlayOneShot(soundSource.clip);

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

    public void OffImages()
    {
        for (int i = 0; i < buttonsObjects.Count; i++)
        {
            var image = buttonsObjects[i].GetComponent<Image>();
            
        }
    }

    public void OnImages()
    {
        
    }
    
    
    
}
