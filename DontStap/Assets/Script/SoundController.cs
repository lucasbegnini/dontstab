﻿using UnityEngine;
using System.Collections;

public class SoundController : MonoBehaviour {
	[SerializeField]
	AudioClip BackgroundGameSound, Stabsound, BackgroundMenuSound,HeartBeatSound,ScreamSound, clickSound;
	
	AudioSource sfx, bgsound, heartbeat;
	
	AudioListener audio;
	
	bool isMute;
	// Use this for initialization
	void Start () {
		this.gameObject.transform.parent = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Transform>();
		bgsound = gameObject.AddComponent<AudioSource>();
		sfx = gameObject.AddComponent<AudioSource>();
		sfx.playOnAwake = false;
		heartbeat = gameObject.AddComponent<AudioSource>();
		heartbeat.playOnAwake = false;
		bgSoundPlay();
		
/*		if (PlayerPrefs.GetInt("Mute") == 1) 
		{
			AudioListener.volume = 0.0f;
		} else {
			AudioListener.volume = 1.0f;
		}
		*/

	}
	
	public void bgSoundPlay()
	{
		if (Application.loadedLevelName.Equals ("menu")) 
		{
			bgsound.clip = BackgroundMenuSound;
		}
		if (Application.loadedLevelName.Equals ("gameplay")) 
		{
			bgsound.clip = BackgroundGameSound;
		}

		bgsound.Play ();
	}
	
	public void pauseSound()
	{
		bgsound.Pause();
		sfx.Pause();
		
	}
	
	public void Stab()
	{
		sfx.clip = Stabsound;
		sfx.Play();
		
	}

	public void Click()
	{
		sfx.clip = clickSound;
		sfx.Play();
		
	}
	
	public void Scream()
	{
		sfx.clip = ScreamSound;
		sfx.Play();
		
	}

	public void HeartBeat()
	{
		heartbeat.clip = HeartBeatSound;
		heartbeat.Play();
		
	}
	
	public void MuteGame()
	{
		if (PlayerPrefs.GetInt("Mute") == 1) {
			isMute = false;
			PlayerPrefs.SetInt("Mute", 0);
			AudioListener.volume = 1.0f;
		} else {
			isMute = true;
			PlayerPrefs.SetInt("Mute", 1);
			AudioListener.volume = 0.0f;
		}
		
	}
	void OnApplicationQuit() 
	{
		PlayerPrefs.SetInt("Mute", 0);
	}
}