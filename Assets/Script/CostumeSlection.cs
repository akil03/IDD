using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class CostumeSlection : MonoBehaviour {

	public int hairIndex = 0;
	public int clothIndex = 0;
	public int costumeIndex = 0;

	public bool hairSelected;
	public bool clothSelected;
	public bool fullConstume;

	public PlaneFinderBehaviour planefinder;
	public GameObject fullbody;

	public CharecterStyle styles;
	public CharecterStyle maincharecter;
	// Use this for initialization

	void Start () {
		//StartCoroutine (randomSelection ());
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	IEnumerator randomSelection() {
		yield return new WaitForSeconds (Random.Range (0, 3));
		maincharecter.fullConstume [costumeIndex].SetActive (false);
		int num = Random.Range (0, 3);
		costumeIndex = num;
		maincharecter.fullConstume [costumeIndex].SetActive (true);
		StartCoroutine (randomSelection ());

	}

	public void Select() {
		planefinder.enabled = true;
	}

	public void Next()
	{
		if (hairSelected == true) {
			styles.hair [hairIndex].SetActive (false);
			maincharecter.hair [hairIndex].SetActive (false);
			hairIndex = hairIndex + 1 != styles.hair.Count ? hairIndex + 1 : 0; 
			maincharecter.hair [hairIndex].SetActive (true);
			styles.hair [hairIndex].SetActive (true);
		} else if (clothSelected == true) {
			styles.Dress [clothIndex].SetActive (false);
			maincharecter.Dress [clothIndex].SetActive (false);
			clothIndex = clothIndex + 1 != styles.Dress.Count ? clothIndex + 1 : 0; 
			styles.Dress [clothIndex].SetActive (true);
			maincharecter.Dress [clothIndex].SetActive (true);
		} else if(fullConstume == true) {
			styles.fullConstume [costumeIndex].SetActive (false);
			maincharecter.fullConstume [costumeIndex].SetActive (false);
			costumeIndex = costumeIndex + 1 != styles.fullConstume.Count ? costumeIndex + 1 : 0; 
			styles.fullConstume [costumeIndex].SetActive (true);
			maincharecter.fullConstume [costumeIndex].SetActive (true);
		}
	}

	public void Previous()
	{
		if (hairSelected == true) {
			styles.hair [hairIndex].SetActive (false);
			maincharecter.hair [hairIndex].SetActive (false);
			hairIndex = hairIndex - 1 < 0 ? hairIndex - 1 : styles.hair.Count -1; 
			maincharecter.hair [hairIndex].SetActive (true);
			styles.hair [hairIndex].SetActive (true);
		} else if (clothSelected == true) {
			styles.Dress [clothIndex].SetActive (false);
			maincharecter.Dress [clothIndex].SetActive (false);
			clothIndex = clothIndex - 1 < 0 ? clothIndex - 1 : styles.Dress.Count -1; 
			styles.Dress [clothIndex].SetActive (true);
			maincharecter.Dress [clothIndex].SetActive (true);
		} else if(fullConstume == true) {
			styles.fullConstume [costumeIndex].SetActive (false);
			maincharecter.fullConstume [costumeIndex].SetActive (false);
			fullbody.GetComponent<Renderer> ().materials[0] = maincharecter.bodyMaterial [costumeIndex];
			costumeIndex = costumeIndex - 1 > -1 ? costumeIndex - 1 : styles.fullConstume.Count -1; 
			styles.fullConstume [costumeIndex].SetActive (true);
			maincharecter.fullConstume [costumeIndex].SetActive (true);
		}
	}
		
}
	
[System.Serializable]
public class CharecterStyle
{
	public List<GameObject> Dress;
	public List<GameObject> hair;
	public List<GameObject> fullConstume;
	public List<Material> bodyMaterial;
}
