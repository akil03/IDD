using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class AnimationControlls : MonoBehaviour {

	public static AnimationControlls instance;

	public Animator charAnimation;
	public AudioSource audio;
	public List<AudioNames> audioname;
	public float audiolenght;
	public string Keyword = "Wave";
	public string audioKey = "Wave";
	public string EndAnimationKey = null;
	public List<EffectName> effects;

	public Animator effectcharAnimator;
	public Transform instantiationPoint;
	public Transform initialCharPoint;

	public GameObject effectSelectionScreen;
	public GameObject effectSelectionCamera;
	public GameObject arCamera;
	public GameObject mainMenu;

	private GameObject particalss;
	private string animationName;

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
		print (Keyword);
		charAnimation.Play (Keyword);

		foreach (var data in audioname) {
			if (data.Audioname == Keyword) {
				print (data.Audioname);
				audio.clip = data.audio;
				audiolenght = data.audio.length;
			}
		}
		audio.Play ();
		StartCoroutine (stopFirstanimation ());
	}

	public IEnumerator stopFirstanimation() {
		yield return new WaitForSeconds (audiolenght);
		StartCoroutine (EndActions ());
	}

	public IEnumerator EndActions()
	{
		print (EndAnimationKey);
		if (EndAnimationKey != "") {
			charAnimation.Play (EndAnimationKey);
			print (charAnimation.GetCurrentAnimatorClipInfo (0).Length);
			yield return new WaitForSeconds (charAnimation.GetCurrentAnimatorClipInfo (0).Length);
			Instantiate (particalss, initialCharPoint, false);
			StartCoroutine (StopANimation(2f));
		} else {
			print ("Skipped");
			StartCoroutine(StopANimation (2f));
		}
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

	public void EndActoionSelection(string actionName) 
	{
		EndAnimationKey = actionName;
	}

	public void EffectSelected(int Index) 
	{
		StopAllCoroutines ();
		EndAnimationKey = effects [Index].animationname;
		particalss = effects [Index].partical;
		effectcharAnimator.Play (effects [Index].animationname);
		StartCoroutine (effectInstantiation (effectcharAnimator.GetCurrentAnimatorClipInfo (0).Length));
	}

	public IEnumerator effectInstantiation(float time)
	{
		yield return new WaitForSeconds (time);
		Instantiate (particalss, instantiationPoint, false);
	}

	public void StartAR() 
	{
		arCamera.SetActive (true);
		mainMenu.SetActive (false);
		//animationSelectionScreen.SetActive (false);
		effectSelectionScreen.SetActive(false);
		effectSelectionCamera.SetActive (false);	
	}

}

[System.Serializable]
public class AudioNames {
	
	public string Audioname;
	public AudioClip audio;
}


[System.Serializable]
public class EffectName {
	public string animationname;
	public GameObject partical;
}