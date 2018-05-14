using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFieldOfView : MonoBehaviour {

	public bool hasPlayer = false;
	public Vector3 playerLocation;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider col) {
		//Debug.Log (col.gameObject.tag);
		if (col.gameObject.tag == "Player") {
			hasPlayer = true;
			playerLocation = col.ClosestPoint (transform.position);
		}
	}

	void OnTriggerStay(Collider col) {
		if (col.gameObject.tag == "Player") {
			hasPlayer = true;
			playerLocation = col.ClosestPoint (transform.position);
		}
	}

	void OnTriggerExit(Collider col) {
		if (col.gameObject.tag == "Player") {
			hasPlayer = false;
			playerLocation = transform.position;
		}
	}
}
