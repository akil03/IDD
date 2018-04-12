using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InstantiateScrollItems : MonoBehaviour {

	public Animator animationCharecter;

	public Transform animationbuttinParent;
	public Transform effectbuttonParent;
	public Transform logoinitiationParent;


	public GameObject button;
	public GameObject effectButton;
	public string[] buttonNames;
	public bool effects;
	public static InstantiateScrollItems instance;

	private GameObject effectinstantiated;

	public List<ButtonNames> animationNames;
	public List<EffectsImage> effectImage;
	// Use this for initialization
	void Start () 
	{
		
			if (effects == false) {
			foreach (var name in animationNames) {
				GameObject obj = Instantiate (button, animationbuttinParent, false);
				obj.GetComponentInChildren<Text> ().text = name.buttonName;
				obj.GetComponent<ButtonAnimator> ().DanceMove = name.animationKey;
			}
			} else 
			{
			foreach (var effect in effectImage) {
				GameObject obj = Instantiate(effectButton, effectbuttonParent, false);
				obj.GetComponent<Image>().sprite = effect.icon;
				obj.GetComponent<ButtonAnimator> ().effect = effect.animationKey;
				obj.GetComponent<ButtonAnimator> ().effectGaf = effect.effectGaf;
			}
			}
		
	}

	void Awake() 
	{
		instance = this;
	}

	public void AnimationButtonClicked() 
	{
		print ("Called");
	}


	public void AnimationCalled(string key) 
	{
		animationCharecter.Play (key);
	}

	public void EffectAnimationcalled(string Key, GameObject logo) 
	{
		if (effectinstantiated) {
			Destroy (effectinstantiated);
		}
		animationCharecter.Play(Key);
		StartCoroutine (starteffect (animationCharecter.GetCurrentAnimatorClipInfo(0).Length,logo));
	}
	public IEnumerator starteffect(float time, GameObject logo)
	{
		yield return new WaitForSeconds (0.5f);
		print (logo.name);
		effectinstantiated = Instantiate (logo, logoinitiationParent, false);
	}
}


[System.Serializable]
public class ButtonNames {
	public string buttonName;
	public string animationKey;
}

[System.Serializable]
public class EffectsImage {
	public string animationKey;
	public Sprite icon;
	public GameObject effectGaf;
}