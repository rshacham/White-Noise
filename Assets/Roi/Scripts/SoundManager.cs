using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager _shared;
    public AudioClip  waterSound;
    public AudioSource mySource1;
    public AudioSource mySource2;
    public AudioSource mySource3;
    public AudioSource mySource4;
    public AudioSource mySource5;

    // Start is called before the first frame
    void Start()
    {
        _shared = this;
        //mySource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    
    public void PlaySound(string myAudio)
    {
        switch (myAudio)
        {

        }
    }

    public void PlayOuterSoundOneTime(AudioSource audioSource, AudioClip mySound)
    {
        audioSource.PlayOneShot(mySound);
    }
    
    
    public void StopSound()
    {
        
    }
}