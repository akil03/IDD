using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class CostumeSlection : MonoBehaviour {
	
	public bool hairSelected;
	public bool clothSelected;
	public bool fullConstume;

	public PlaneFinderBehaviour planefinder;
	public List<CharecterStyle> stylebodyparts;

	void Start () {
	}

	public void Select() {
		MainUiController.instance.CharecterSelectionDone ();
	}

	public void Next()
	{
		if (hairSelected == true) {
//			styles.hair [hairIndex].SetActive (false);
//			maincharecter.hair [hairIndex].SetActive (false);
//			hairIndex = hairIndex + 1 != styles.hair.Count ? hairIndex + 1 : 0; 
//			maincharecter.hair [hairIndex].SetActive (true);
//			styles.hair [hairIndex].SetActive (true);
		} else if (clothSelected == true) {
//			styles.Dress [clothIndex].SetActive (false);
//			maincharecter.Dress [clothIndex].SetActive (false);
//			clothIndex = clothIndex + 1 != styles.Dress.Count ? clothIndex + 1 : 0; 
//			styles.Dress [clothIndex].SetActive (true);
//			maincharecter.Dress [clothIndex].SetActive (true);
		} else if(fullConstume == true) {
			foreach (var objects in stylebodyparts) 
			{
				objects.fullConstume [objects.Index].SetActive (false);
				objects.Index = objects.Index + 1 != objects.fullConstume.Count ? objects.Index + 1 : 0; 
				objects.fullConstume [objects.Index].SetActive (true);
				objects.body.material = objects.bodyMaterial [objects.Index];
			}

		}
	}

	public void Previous()
	{
		if (hairSelected == true) {
//			styles.hair [hairIndex].SetActive (false);
//			maincharecter.hair [hairIndex].SetActive (false);
//			hairIndex = hairIndex - 1 < 0 ? hairIndex - 1 : styles.hair.Count -1; 
//			maincharecter.hair [hairIndex].SetActive (true);
//			styles.hair [hairIndex].SetActive (true);
		} else if (clothSelected == true) {
//			styles.Dress [clothIndex].SetActive (false);
//			maincharecter.Dress [clothIndex].SetActive (false);
//			clothIndex = clothIndex - 1 < 0 ? clothIndex - 1 : styles.Dress.Count -1; 
//			styles.Dress [clothIndex].SetActive (true);
//			maincharecter.Dress [clothIndex].SetActive (true);
		} else if(fullConstume == true) {

			foreach (var objects in stylebodyparts) 
			{
				objects.fullConstume [objects.Index].SetActive (false);
				objects.Index = objects.Index -1> -1 ? objects.Index - 1 : objects.fullConstume.Count -1; 
				objects.fullConstume [objects.Index].SetActive (true);
				objects.body.material = objects.bodyMaterial [objects.Index];
			}

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
	public Renderer body;
	public int Index = 0;
}
