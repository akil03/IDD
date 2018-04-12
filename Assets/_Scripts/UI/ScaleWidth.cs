using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleWidth : MonoBehaviour {



	// Use this for initialization
	void Start () {
		int count = transform.childCount;
		if (count > 5) {
			var theBarRectTransform = transform as RectTransform;
			theBarRectTransform.sizeDelta = new Vector2 (count*175, theBarRectTransform.sizeDelta.y);
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
