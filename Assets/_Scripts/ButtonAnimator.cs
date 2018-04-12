using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonAnimator : MonoBehaviour {
	public string DanceMove;
	public string effect;
	public GameObject effectGaf;
	void Start () {
		
	}

	void Update () {
		
	}

	public void OnClick(){
		InstantiateScrollItems.instance.AnimationCalled (DanceMove);
		AnimationControlls.instance.Keyword = DanceMove;
	}

	public void OnEffectClick() {
		InstantiateScrollItems.instance.EffectAnimationcalled (effect,effectGaf);
		AnimationControlls.instance.EndAnimationKey = effect;
		AnimationControlls.instance.effectImage = effectGaf;
	}
}
