using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGeneration : MonoBehaviour {

	public bool generateNewSeed;
	public int seed;
	public Socket[] sockets;

	// Use this for initialization
	void Start () {
		if (generateNewSeed) {
			seed = Random.Range (0, int.MaxValue);
		}
		GenerateLevel ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void GenerateLevel() {
		for (int i = 0; i < sockets.Length; i++) {
			sockets [i].GenerateRoom ();
		}
	}
}
