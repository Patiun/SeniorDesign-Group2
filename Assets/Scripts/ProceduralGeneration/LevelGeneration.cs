using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGeneration : MonoBehaviour {

	public bool generateNewSeed;
	public int seed;
	public GameObject socketGroup;
	public GameObject elevatorSocketPrefab;
	public Socket elevatorSocket;
	public List<Socket> sockets;

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
		sockets = new List<Socket>();
		for (int i = 0; i < childCount; i++) {
			GameObject child = socketGroup.transform.GetChild (i).gameObject;
			Socket socket = child.GetComponent<Socket> ();
			if (socket != null) {
				sockets.Add (socket);
			}
		}
	}

	private void GenerateLevel() {
		if (elevatorSocket == null) {
			//GENERATE ELEVATOR
			List<Socket> squares = new List<Socket>();
			for (int i = 0; i < sockets.Count; i++) {
				if (sockets [i].socketType == Socket.SocketType.SQUARE) {
					squares.Add (sockets [i]);
				}
			}
			int elevatorInd = Random.Range (0, squares.Count);
			GameObject targetSocket = squares [elevatorInd].transform.gameObject;
			sockets.Remove (squares [elevatorInd]);
			GameObject elevator = Instantiate (elevatorSocketPrefab);
			elevator.transform.position = targetSocket.transform.position;
			elevator.transform.parent = targetSocket.transform.parent;
			sockets.Add (elevator.GetComponent<Socket> ());
			Destroy (targetSocket);
		}
		
		for (int i = 0; i < sockets.Count; i++) {
			sockets [i].GenerateRoom ();
		}
		for (int i = 0; i < sockets.Count; i++) {
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
