using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGeneration : MonoBehaviour {

	public bool generateNewSeed;
	public int seed;
	public GameObject socketGroup;
	public Socket[] sockets;

	// Use this for initialization
	void Start () {
		if (generateNewSeed) {
			seed = Random.Range (0, int.MaxValue);
		}
		if (socketGroup != null) {
			LoadSockets ();
		}
		GenerateLevel ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void LoadSockets() {
		int childCount = socketGroup.transform.childCount;
		sockets = new Socket[childCount];
		for (int i = 0; i < childCount; i++) {
			GameObject child = socketGroup.transform.GetChild (i).gameObject;
			Socket socket = child.GetComponent<Socket> ();
			if (socket != null) {
				sockets [i] = socket;
			}
		}
	}

	private void GenerateLevel() {
		for (int i = 0; i < sockets.Length; i++) {
			sockets [i].GenerateRoom ();
		}
		for (int i = 0; i < sockets.Length; i++) {
			sockets [i].GenerateDoors ();
		}
		TrapPopulation trapPop = GetComponent<TrapPopulation> ();
		if (trapPop != null && trapPop.isActiveAndEnabled) {
			trapPop.GenerateTraps ();
		}
		EnemyPopulation enemyPop = GetComponent<EnemyPopulation> ();
		if (enemyPop != null && enemyPop.isActiveAndEnabled) {
			enemyPop.GenerateEnemies ();
		}
	}
}
