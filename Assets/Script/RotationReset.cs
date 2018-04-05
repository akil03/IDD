using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationReset : MonoBehaviour {

	public GameObject arcam;

	RaycastHit Hit;


	// Use this for initialization
	void Start () {
		transform.LookAt (arcam.transform);
		transform.rotation = Quaternion.Euler (0, transform.rotation.y, 0);
	}
	
	// Update is called once per frame
	void Update () {
			
	}


}
