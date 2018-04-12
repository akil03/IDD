﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleWidth : MonoBehaviour {

	public float multiplerCount;
	public string direction;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		int count = transform.childCount;
		var theBarRectTransform = transform as RectTransform;
		if (count > 5) {
			if (direction == "Column" || direction == "column") {
				theBarRectTransform.sizeDelta = new Vector2 (theBarRectTransform.sizeDelta.x, count * multiplerCount);
			} else if (direction == "Row" || direction == "row") {
				theBarRectTransform.sizeDelta = new Vector2 (count * multiplerCount,theBarRectTransform.sizeDelta.y);
			}
		}
	}
}
