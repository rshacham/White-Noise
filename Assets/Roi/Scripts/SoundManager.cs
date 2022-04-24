using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager _shared;
    public AudioClip  waterSound;
    public AudioSource mySource1;
    public AudioSource mySource2;
    public AudioSource mySource3;
    public AudioSource mySource4;

    [SerializeField] public AudioSource startingSoundSource;
    public bool firstSoundPlayed;
    [SerializeField] public GameObject tutorial;
    [SerializeField] public GameObject logo;


    public List<AudioSource> mySources;
    public bool loopSound;
    [SerializeField] public List<float> mySpeeds;
    public Dictionary<AudioSource, float> LooperEnumerators = new Dictionary<AudioSource, float>();
    [SerializeField] private List<Animator> gameAnimators;
    


    // Start is called before the first frame
    void Start()
    {
        mySources.Add(mySource1);
        mySources.Add(mySource2);
        mySources.Add(mySource3);
        mySources.Add(mySource4);

        foreach (var animator in gameAnimators)
        {
            animator.enabled = false;
        }
        tutorial.SetActive(false);
        startingSoundSource.time = 2f;
        startingSoundSource.Play();
        firstSoundPlayed = true;


        _shared = this;
        //mySource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (firstSoundPlayed && !startingSoundSource.isPlaying)
        {
            firstSoundPlayed = false;
            startingSoundSource.clip = null;
            tutorial.SetActive(true);
        }
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
        if (audioSource.isPlaying)
        {
            audioSource.Stop();
        }
        //audioSource.clip = mySound;
        audioSource.Play();
    }


    public Coroutine StartLooper(SoundButton myScript, AudioSource audioSource, AudioClip mySound, int currentDelay)
    {
        audioSource.clip = mySound;
        if (!LooperEnumerators.ContainsKey(audioSource))
        {
            LooperEnumerators.Add(audioSource, currentDelay);
        }
        return StartCoroutine(LooperSpeed(myScript, audioSource, mySound));
    }
    public void StopSound()
    {
        
    }

    IEnumerator LooperSpeed(SoundButton myScript, AudioSource audioSource, AudioClip mySound)
    {
        while (true)
        {
            if (LooperEnumerators[audioSource] < 50 && myScript.loopButton.isOn)
            {
                audioSource.Play();
                Debug.Log(LooperEnumerators[audioSource] + audioSource.clip.length);
                yield return new WaitForSeconds(LooperEnumerators[audioSource] + (audioSource.clip.length / audioSource.pitch) - myScript.recordDelay / audioSource.pitch);
            }
            
            else
            {
                yield return new WaitForSeconds(1);
            }
        }
    }

    public bool OneClipLoaded()
    {
        foreach (var source in mySources)
        {
            if (source.clip != null)
            {
                return true;
            }
        }
        return false;
    }

    public void TurnOnAnimations()
    {
        print("hey");

        foreach (var animator in gameAnimators)
        {
            print("hey");
            animator.enabled = true;
        }
    }
}