using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapPopulation : MonoBehaviour {

	public int numTraps;
	public GameObject trapGroup; 
	public TrapPoint[] trapPoints;

	private List<TrapPoint> used, unused;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void LoadTrapGroup() {
		int childCount = trapGroup.transform.childCount;
		trapPoints = new TrapPoint[childCount];
		for (int i = 0; i < childCount; i++) {
			GameObject child = trapGroup.transform.GetChild (i).gameObject;
			TrapPoint trapPoint = child.GetComponent<TrapPoint> ();
			if (trapPoint != null) {
				trapPoints [i] = trapPoint;
			}
		}
	}

	public void GenerateTraps(int seed) {
		Random.InitState (seed);
		if (trapGroup != null) {
			LoadTrapGroup ();
		}

		LevelDifficulty levelDifficulty = GetComponent<LevelDifficulty> ();
		if (levelDifficulty != null) {
			numTraps = levelDifficulty.numTraps;
		}

		unused = new List<TrapPoint> (trapPoints);
		used = new List<TrapPoint> ();
		for (int i = 0; i < numTraps; i++) {
			int trapInd = Random.Range (0, unused.Count);
			if (!unused [trapInd].Generate ())
				i--;
			used.Add (unused [trapInd]);
			unused.RemoveAt (trapInd);
		}
	}
}
