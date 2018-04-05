using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationControlls : MonoBehaviour {

	public Animator charAnimation;
	public AudioSource audio;

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
		charAnimation.Play ("Play");
		audio.Play ();
		float length = charAnimation.GetCurrentAnimatorClipInfo (0).Length;

	}

	public void StopAnimation() {
		RecScript.instance.StopRecord ();
	}

}
