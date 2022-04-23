using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoopButton : MonoBehaviour
{
    [SerializeField] private List<Sprite> mySprites;

    public int looperCounter;
    public bool isOn = false;
    public SoundButton soundScript;

    public void Update()
    {
        Image myImage = this.gameObject.GetComponent<Image>();
        if (soundScript.soundSource.clip == null)
        {
            myImage.sprite = mySprites[0];
        }

        else if (isOn)
        {
            myImage.sprite = mySprites[2];
        }

        else
        {
            myImage.sprite = mySprites[1];
        }
    }

    public void PressedLoop()
    {
        isOn = !isOn;

        if (!isOn)
        {
            if (soundScript.soundSource.isPlaying)
            {
                soundScript.soundSource.Stop();
            }
        }

        soundScript.looperCounter--;
        soundScript.ChangeLooper();
    }
    
}
