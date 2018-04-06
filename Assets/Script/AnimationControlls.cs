using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationControlls : MonoBehaviour {

	public Animator charAnimation;
	public AudioSource audio;
	public string Keyword = "TakeL";


	void OnEnable() 
	{
		RecScript.RecordPlayer += On_play;
		CharecterActionManager.PlayAnimation += On_play;
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
		audio.Play ();
		//Resources.Load('Audio/Wave');
		float time = charAnimation.GetCurrentAnimatorClipInfo (0).Length;
		StartCoroutine (StopANimation (25.10f));
	}

	IEnumerator StopANimation(float time) 
	{
		yield return new WaitForSeconds (time);
		RecScript.instance.StopRecord ();
	}

	public void Animation(string Key) {
		Keyword = Key;
	}

}
