using System;
using System.Collections.Generic;
using UnityEngine; //41 Post - Created by DimasTheDriver on July/28/2012 . Part of the 'Unity: Capturing audio from a microphone' post. Available at: http://www.41post.com/?p=4884
using System.Collections;
using System.IO;
using TMPro;
using UnityEngine.UI;

[RequireComponent (typeof (AudioSource))]

public class RecordWithButton : MonoBehaviour 
{
	//A boolean that flags whether there's a connected microphone
	private bool micConnected = false;
	private bool timerFinished = false;
	public bool recordOn = false;
	public bool loaded = false;
	[SerializeField] private int recordNum;
	[SerializeField] public GameObject recordButton;
	[SerializeField] private int oneRecordTime;
	[SerializeField] private SoundButton soundScript;
	
	private float curRecordTime = 0;
	[SerializeField] private Image buttonImage;
	[SerializeField] private List<Sprite> buttonSprites;
	
	
	//The maximum and minimum available recording frequencies
	private int minFreq;
	private int maxFreq;
	
	//A handle to the attached AudioSource
	private AudioSource goAudioSource;
	
	//Use this for initialization
	void Start() 
	{
		//Check if there is at least one microphone connected
		if(Microphone.devices.Length <= 0)
		{
			//Throw a warning message at the console if there isn't
			Debug.LogWarning("Microphone not connected!");
		}
		else //At least one microphone is present
		{
			//Set 'micConnected' to true
			micConnected = true;
			
			//Get the default microphone recording capabilities
			Microphone.GetDeviceCaps(null, out minFreq, out maxFreq);
			
			//According to the documentation, if minFreq and maxFreq are zero, the microphone supports any frequency...
			if(minFreq == 0 && maxFreq == 0)
			{
				//...meaning 44100 Hz can be used as the recording sampling rate
				maxFreq = 44100;
			}
			
			//Get the attached AudioSource component
			goAudioSource = this.GetComponent<AudioSource>();
		}
	}
	
	
	public void Record()
	{
		//If there is a microphone
		if(micConnected)
		{
			//If the audio from any microphone isn't being recorded
			if(!Microphone.IsRecording(null))
			{
				soundScript.soundSource.clip = null;
				recordOn = true;
				curRecordTime = 0;
				//Start recording and store the audio captured from the microphone at the AudioClip in the AudioSource
					goAudioSource.clip = Microphone.Start(null, true, oneRecordTime, maxFreq);
					//Start coroutine that automatically stops the record
					StartCoroutine(FinishTimer());
			}
			
			else //Recording is in progress
			{
				//Case the 'Stop and Play' button gets pressed, or time ended
					
					StopRecord();
			}
		}
		
		else // No microphone
		{
			//Print a red "Microphone not connected!" message at the center of the screen
			GUI.contentColor = Color.red;
			GUI.Label(new Rect(Screen.width/2-100, Screen.height/2-25, 200, 50), "Microphone not connected!");
		}
	}

	private void StopRecord()
	{
		soundScript.soundSource.clip = null;
		recordOn = false;
		Microphone.End(null); //Stop the audio recording
		if (curRecordTime < oneRecordTime)
		{
			loaded = false;
			curRecordTime = 0;
			buttonImage.sprite = buttonSprites[0];
			return;
		}

		if (!SoundManager._shared.OneClipLoaded())
		{
			SoundManager._shared.TurnOnAnimations();
		}
		
		soundScript.TurnButtons(true);
		loaded = true;
		soundScript.soundSource.clip = goAudioSource.clip;
		String soundPath = "record" + recordNum.ToString();
		SavWav.Save(soundPath, goAudioSource.clip);
		//soundScript.soundPath = Path.Combine(Application.dataPath, soundPath);
		//goAudioSource.Play(); //Playback the recorded audio
		//soundScript.LoadSound(Path.Combine(Application.dataPath, soundPath));
	}

	void Update()
	{
		float normalizedValue = Mathf.InverseLerp(0, oneRecordTime, curRecordTime);
		float curSprite = Mathf.Lerp(0, buttonSprites.Count - 1, normalizedValue);
		if (curSprite > 9)
		{
			curSprite = 9;
		}
		buttonImage.sprite = buttonSprites[(int) curSprite];
		if (recordOn)
		{
			curRecordTime += Time.deltaTime;
		}
	}

	IEnumerator FinishTimer()
	{
		yield return new WaitForSeconds(oneRecordTime);
		soundScript.soundSource.clip = null;
		if (Microphone.IsRecording(null) && curRecordTime >= oneRecordTime)
		{
			StopRecord();
		}
		
	}

	public void StartAndStopRecord()
	{
		recordOn = !recordOn;
	}
}
