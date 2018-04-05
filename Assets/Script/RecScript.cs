﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.iOS;
using UnityEngine.Apple.ReplayKit;
using UnityEngine.Playables;
using HedgehogTeam.EasyTouch;
using DG.Tweening;

public class RecScript : MonoBehaviour {
	public Animation animationClip;
	public GameObject[] Codown;
	public static RecScript instance;

	public delegate void RecordPressed();
	public static event RecordPressed RecordPlayer;
	public Animator charAnimator;
	public AudioSource charAudio;
	public bool isRecordingComplete;
	void Awake(){
		instance = this;
	}



	void OnEnable() {
		EasyTouch.On_DoubleTap += On_DoubleTap;
	}

	void OnDisable() {
		EasyTouch.On_DoubleTap -= On_DoubleTap;
	}

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		EasyTouch.On_DoubleTap += On_DoubleTap;
	}


	public void On_DoubleTap(Gesture gesture) 
	{
		print ("Doubletap");
		StopRecord ();

	}

	public void Record(){
		

		if (!ReplayKit.isRecording) {
			RecordPlayer ();
			ReplayKit.StartRecording ();
			isRecordingComplete = false;
			print ("recording");
			Invoke ("StopRecord", 15);
			//isRecording = true;
		}
	}

	public void StopRecord(){
		
		charAnimator.Play ("Idle");
		charAudio.Stop ();
		print ("STOPPED");
		ReplayKit.StopRecording ();
		//if(!isRecordingComplete)
			StartCoroutine (ShowRecording ());

		if (ReplayKit.isRecording) {
			
		}
	}

	IEnumerator ShowRecording(){
		
		isRecordingComplete = true;
		print ("rePLAY BEGIN");
		while (!ReplayKit.recordingAvailable) 
		//{
			yield return null;
		//}
		//yield return new WaitForEndOfFrame ();
	//	print ("rePLAY END");
		ReplayKit.Preview ();
	}



	public void Countdown(){
		Codown [0].SetActive (true);
		Codown [0].transform.DOScale (new Vector3 (0.2f, 0.2f, 0.2f), 1f).OnComplete (() => {
			Codown [1].SetActive (true);
			Codown [0].SetActive (false);
			Codown[0].transform.localScale = new Vector3(1f,1f,1f);
			Codown [1].transform.DOScale (new Vector3 (0.2f, 0.2f, 0.2f), 1f).OnComplete (() => {
				Codown [2].SetActive (true);
				Codown [1].SetActive (false);
				Codown[1].transform.localScale = new Vector3(1f,1f,1f);
				Codown [2].transform.DOScale (new Vector3 (0.2f, 0.2f, 0.2f), 1f).OnComplete (() => {
					Codown [2].SetActive (false);
					Codown[2].transform.localScale = new Vector3(1f,1f,1f);
					Record ();
				});
			});
		});
	}
}
