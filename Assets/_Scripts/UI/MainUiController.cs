using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class MainUiController : MonoBehaviour {

	public static MainUiController instance;
	public PlaneFinderBehaviour plane;
	public GameObject groundplane;

	public GameObject[] screens;
	public GameObject Arcamera;


	void Awake() {
		instance = this;
	}

	public void CharecterSelectionDone(){
		screens [0].SetActive (false);
		screens [1].SetActive (true);
	}

	public void AnimationSelectionDone() {
		screens [1].SetActive (false);
		screens [2].SetActive (true);
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
		screens [2].SetActive (false);
		screens [1].SetActive (true);
	}
}
