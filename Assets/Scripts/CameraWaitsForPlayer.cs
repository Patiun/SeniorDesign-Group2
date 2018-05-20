using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraWaitsForPlayer : MonoBehaviour {

	public List<GameObject> thingsToToggle;
	public bool hasPlayer;

	// Use this for initialization
	void Start () {
		ToggleOff ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider col) {
		if (col.tag == "Player") {
			hasPlayer = true;
			ToggleOn ();
		}
	}

	private void ToggleOn() {
		foreach (GameObject go in thingsToToggle) {
			go.SetActive (true);
		}
	}

	void OnTriggerExit(Collider col) {
		if (col.tag == "Player") {
			hasPlayer = false;
			ToggleOff ();
		}
	}

	private void ToggleOff() {
		foreach (GameObject go in thingsToToggle) {
			go.SetActive (false);
		}
	}
}
