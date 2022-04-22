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

    public void PressedLoop()
    {
        isOn = !isOn;
        Image myImage = this.gameObject.GetComponent<Image>();

        if (isOn)
        {
            myImage.sprite = mySprites[1];
        }

        else
        {
            myImage.sprite = mySprites[0];
        }

        soundScript.looperCounter--;
        soundScript.ChangeLooper();
    }
    
}
