using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class AnimationControlls : MonoBehaviour {

	public static AnimationControlls instance;

	public Animator charAnimation;
	public AudioSource audio;
//	public AudioClip[] audios;
//	public AudioClip Wave;
//	public AudioClip Worm;
//	public AudioClip Clap;
//	public AudioClip TakeL;
//	public AudioClip Robot;
//	public AudioClip Electro;
//	public AudioClip Salt;
	public List<AudioNames> audioname;
	public float audiolenght;
	public string Keyword = "Wave";
	public string audioKey = "Wave";


	void OnEnable() 
	{
		RecScript.RecordPlayer += On_play;
		CharecterActionManager.PlayAnimation += On_play;
	}

	void Awake () {
		instance = this;
	}

	void OnDisable() 
	{
		RecScript.RecordPlayer -= On_play;
		CharecterActionManager.PlayAnimation -= On_play;
	}
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void On_play() {
		charAnimation.Play (Keyword);

		foreach (var data in audioname) {
			if (data.Audioname == Keyword) {
				print (data.Audioname);
				audio.clip = data.audio;
				audiolenght = data.audio.length;
			}
		}
		audio.Play ();
		StartCoroutine (StopANimation (audiolenght));
	}

	public IEnumerator StopANimation(float time) 
	{
		yield return new WaitForSeconds (time);
		RecScript.instance.StopRecord ();
	}

	public void Animation(string Key) {
		Keyword = Key;
		audioKey = Key;
	}

}

[System.Serializable]
public class AudioNames {
	
	public string Audioname;
	public AudioClip audio;
}
