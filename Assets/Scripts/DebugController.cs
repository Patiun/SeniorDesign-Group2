using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugController : MonoBehaviour {

	public bool isDebugging = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown ("`")) {
			isDebugging = !isDebugging;
			if (isDebugging) {
				Debug.Log ("Debug Mode is Enabled");
			} else {
				Debug.Log ("Debug Mode is Disabled");
			}
		}

		if (isDebugging) {



		}
	}
}
