using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapPopulation : MonoBehaviour {

	public int numTraps;
	public TrapPoint[] trapPoints;

	private List<TrapPoint> used, unused;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void GenerateTraps() {
		unused = new List<TrapPoint> (trapPoints);
		used = new List<TrapPoint> ();
		for (int i = 0; i < numTraps; i++) {
			int trapInd = Random.Range (0, unused.Count);
			unused [i].Generate ();
			used.Add (unused [i]);
			unused.RemoveAt (i);
		}
	}
}
