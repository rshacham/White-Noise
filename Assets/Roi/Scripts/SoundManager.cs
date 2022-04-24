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
    public AudioSource[] mySources;

    public bool loopSound;
    [SerializeField] public List<float> mySpeeds;
    public Dictionary<AudioSource, float> LooperEnumerators = new Dictionary<AudioSource, float>();

    // Start is called before the first frame
    void Start()
    {
        _shared = this;
        mySources.Append(mySource1);
        mySources.Append(mySource2);
        mySources.Append(mySource3);
        mySources.Append(mySource4);

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
        audioSource.clip = mySound;
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
                yield return new WaitForSeconds(LooperEnumerators[audioSource] + (audioSource.clip.length / audioSource.pitch));
            }
            else
            {
                yield return new WaitForSeconds(1);
            }
        }
    }

    public bool OneClipLoaded()
    {
        bool result = false;
        foreach (var source in mySources)
        {
            if (source.clip != null)
            {
                result = true;
                break;
            }
        }
        return result;
    }
}