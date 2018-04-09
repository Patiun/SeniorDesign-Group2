using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugController : MonoBehaviour {

	public bool isDebugging = false;
	public WorldState worldState;
	private WorldState.State lastState;

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
			if (Input.GetKeyDown("up")) {
				worldState.MajorActivity();
			}
			if (Input.GetKeyDown("down")) {
				worldState.MinorActivity();
			}
			if (Input.GetKeyDown("r")) {
				worldState.Reset();
			}
			WorldState.State curState = worldState.GetState ();
			if (curState != lastState) {
				Debug.Log (curState);
				lastState = curState;
			}
		}
	}
}
