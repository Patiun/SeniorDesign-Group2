using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DifficultySelect : MonoBehaviour {
    
	public Material originalMaterial;
	public GameObject buttonOne;
	public GameObject buttonTwo;

	private bool flash;

	// Use this for initialization
	void Start () {
		flash = false;
	}
	
	// Update is called once per frame
	void Update () {

	}

	private void OnMouseDown(){
		buttonOne.GetComponent<DifficultySelect>().flash = false;
		buttonTwo.GetComponent<DifficultySelect>().flash = false;
		gameObject.GetComponent<Renderer>().material = originalMaterial;
        buttonOne.GetComponent<Renderer>().material = originalMaterial;
		buttonTwo.GetComponent<Renderer>().material = originalMaterial;
	}
   
}
