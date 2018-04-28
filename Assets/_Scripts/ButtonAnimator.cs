using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class ButtonAnimator : MonoBehaviour {
	public string DanceMove;
	public string effect;
	public GameObject effectGaf;
	public FaceExpressions expTime;
	public AudioClip audios;
	public RenderTexture RenderImage;
	public Ease easeType;
	public List<FallObjectsIming> fallingObjects;

	void Start () {
		
	}

	void Update () {
		
	}

	public void OnClick(){
		InstantiateScrollItems.instance.AnimationCalled (DanceMove, audios, expTime);
		AnimationControlls.instance.Keyword = DanceMove;
		AnimationControlls.instance.audioTest = audios;
		AnimationControlls.instance.fallingObjects = fallingObjects;
		AnimationControlls.instance.expTime = expTime;
		AnimationControlls.instance.fallingObjects = fallingObjects;
	}

	public void OnEffectClick() {
		InstantiateScrollItems.instance.EffectAnimationcalled (effect,effectGaf,expTime);
		AnimationControlls.instance.EndAnimationKey = effect;
		AnimationControlls.instance.effectImage = effectGaf;
		AnimationControlls.instance.expTime = expTime;
	}
}
