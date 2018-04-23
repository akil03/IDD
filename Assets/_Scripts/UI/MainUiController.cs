using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class MainUiController : MonoBehaviour {

	public static MainUiController instance;
	public PlaneFinderBehaviour plane;
	public GameObject groundplane;
	public AudioSource uiCharecterAudio;
	public Animator uicharecterAnimator;
	public GameObject[] screens;
	public GameObject Arcamera;

	public bool effectsinstantiated =  false;

	void Awake() {
		instance = this;
	}

	public void CharecterSelectionDone(){
		InstantiateScrollItems.instance.effects = false;
		screens [0].SetActive (false);
		screens [1].SetActive (true);
	}

	public void AnimationSelectionDone() {
		InstantiateScrollItems.instance.effects = true;
		if (!effectsinstantiated) {
			InstantiateScrollItems.instance.InstantiateCalled ();
			effectsinstantiated = true;
		}
		screens [1].SetActive (false);
		screens [2].SetActive (true);
		uiCharecterAudio.Stop ();
		uicharecterAnimator.Play ("Idle");
	}

	public void EffectSelectionDone() {
		screens [2].SetActive (false);
		plane.enabled = true;
	}

	public void HomeScreenPressed() {
		groundplane.SetActive (false);
		DeployStageOnce.instance.placed = false;
		plane.enabled = true;
		screens [1].SetActive (true);
	}

	public void EditProfileSelected() {
		screens [1].SetActive (false);
		screens [0].SetActive (true);
	}

	public void ChangeAnimation() {
		
		InstantiateScrollItems.instance.effects = false;
		screens [2].SetActive (false);
		screens [1].SetActive (true);

	}
}
