using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapPopulation : MonoBehaviour {

	public TrapPoint[] trapPoints;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void GenerateTraps() {
		for (int i = 0; i < trapPoints.Length; i++) {
			trapPoints [i].Generate ();
		}
	}
}
