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
	public AudioSource bodyAudio;

	public int charecterSelectionindex;

	void Start () 
	{
		InstantiateCalled ();
	}

	public void InstantiateCalled() {
		if (effects == false) {
			foreach (var name in animationNames) {
				GameObject obj = Instantiate(button, animationbuttinParent, false);
				obj.transform.localScale = Vector3.one;
				print (name.icon [charecterSelectionindex]);
				obj.GetComponent<Image>().sprite = name.icon[charecterSelectionindex];

				obj.GetComponent<ButtonAnimator> ().audios = name.audios;
				obj.GetComponent<ButtonAnimator> ().DanceMove = name.animationKey;
				obj.GetComponent<ButtonAnimator> ().expTime = name.expTime;
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

	public void DestroyObjects() {
		foreach (Transform obj in animationbuttinParent) {
			Destroy (obj.gameObject);
		}
	}

	void Awake() 
	{
		instance = this;

	}

	void Update() {
		//charecterSelectionindex = AnimationControlls.instance.charecterSelectionIndex;

	}

	public void AnimationButtonClicked() 
	{
		print ("Called");
	}


	public void AnimationCalled(string key, AudioClip Audio, FaceExpressions Test)
	{
		StopAllCoroutines ();
		if (effectinstantiated) {
			Destroy (effectinstantiated);
		}
		bodyAudio.clip = Audio;
		bodyAudio.Play ();
		StartCoroutine (emmotionStart (Test));
		StartCoroutine (StopAnimation (Audio.length));
		animationCharecter.Play (key);

	}

	public IEnumerator StopAnimation(float time) {
		yield return new WaitForSeconds (time);
		animationCharecter.Play ("Idle");
	}

	public IEnumerator emmotionStart(FaceExpressions Key) {
		foreach (var obj in Key.expressionTimes) {
					Material[] mat = boyBody.materials;
					mat [2] = obj.faceAction[charecterSelectionindex];
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
		effectinstantiated = Instantiate (logo, logoinitiationParent, false);
	}
}


[System.Serializable]
public class ButtonNames {
	public Sprite[] icon;
	public string animationKey;
	public AudioClip audios;
	public FaceExpressions expTime;
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
	public List<Material> faceAction;
}
