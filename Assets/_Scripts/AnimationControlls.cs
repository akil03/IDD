using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class AnimationControlls : MonoBehaviour {

	public static AnimationControlls instance;

	public Animator charAnimation;
	public AudioSource audio;
	public GameObject effectImage;
	public List<AudioNames> audioname;
	public float audiolenght;
	public string Keyword = "TakeL";
	public string audioKey;
	public string EndAnimationKey = null;
	public List<EffectName> effects;

	public Animator effectcharAnimator;
	public Transform[] instantiationPoint;
	public Transform initialCharPoint;

	public GameObject effectSelectionScreen;
	public GameObject effectSelectionCamera;
	public GameObject arCamera;
	public GameObject mainMenu;

	public FaceExpressions expTime;
	public Renderer mainBody;

	private GameObject instantiatedImage;

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

	void Start () {
		
	}

	void Update () {
		
	}

	void On_play() {
		print (Keyword);
		charAnimation.Play (Keyword);
		if (instantiatedImage) {
			Destroy (instantiatedImage);
		}

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

	public IEnumerator emmotionStart(FaceExpressions Key) {
		foreach (var obj in Key.expressionTimes) {
			Material[] mat = mainBody.materials;
			mat [2] = obj.faceAction;
			mainBody.materials = mat;
			yield return new WaitForSeconds (obj.time);
		}
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
			StartCoroutine (emmotionStart(expTime));
			yield return new WaitForSeconds (1f);
			instantiatedImage = Instantiate (effectImage, instantiationPoint[UnityEngine.Random.Range(0,instantiationPoint.Length)], false);
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
		effectcharAnimator.Play (effects [Index].animationname);
		StartCoroutine (effectInstantiation (effectcharAnimator.GetCurrentAnimatorClipInfo (0).Length));
	}

	public IEnumerator effectInstantiation(float time)
	{
		yield return new WaitForSeconds (time);
	}

	public void StartAR() 
	{
		arCamera.SetActive (true);
		mainMenu.SetActive (false);
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