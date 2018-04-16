using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InstantiateScrollItems : MonoBehaviour {

	public Animator animationCharecter;

	public Transform animationbuttinParent;
	public Transform effectbuttonParent;
	public Transform logoinitiationParent;

	public Renderer boyBody;

	public GameObject button;
	public GameObject effectButton;
	public string[] buttonNames;
	public bool effects;
	public static InstantiateScrollItems instance;

	private GameObject effectinstantiated;

	public List<ButtonNames> animationNames;
	public List<EffectsImage> effectImage;
	public List<FaceExpressions> expressions;

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
				obj.transform.localScale = Vector3.one;
				obj.GetComponent<Image>().sprite = effect.icon;
				obj.GetComponent<ButtonAnimator> ().effect = effect.animationKey;
				obj.GetComponent<ButtonAnimator> ().effectGaf = effect.effectGaf;
				obj.GetComponent<ButtonAnimator> ().expTime = effect.expTime;
			}

			}
		int count = transform.childCount;
		var theBarRectTransform = transform as RectTransform;
		if (count > 5) {
				theBarRectTransform.sizeDelta = new Vector2 (theBarRectTransform.sizeDelta.x, count * 300);
			
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
		StopAllCoroutines ();
		if (effectinstantiated) {
			Destroy (effectinstantiated);
		}
		animationCharecter.Play (key);

	}

	public IEnumerator emmotionStart(FaceExpressions Key) {
		
		foreach (var obj in Key.expressionTimes) {
					Material[] mat = boyBody.materials;
					mat [2] = obj.faceAction;
					boyBody.materials = mat;
					yield return new WaitForSeconds (obj.time);
				}
	}

	public void EffectAnimationcalled(string Key, GameObject logo, FaceExpressions expTime) 
	{
		StopAllCoroutines ();
		if (effectinstantiated) {
			Destroy (effectinstantiated);
		}
		animationCharecter.Play(Key);
		StartCoroutine (emmotionStart (expTime));
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
	public FaceExpressions expTime;
}

[System.Serializable]

public class FaceExpressions {
	public List<expressionTime> expressionTimes;
}

[System.Serializable]
public class expressionTime {
	public float time;
	public Material faceAction;
}