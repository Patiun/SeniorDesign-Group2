using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGeneration : MonoBehaviour {

	public static LevelGeneration SharedInstance;

	public bool generateNewSeed;
	public int seed;
	public GameObject socketGroup;
	public GameObject elevatorSocketPrefab;
	public Socket elevatorSocket;
	public List<Socket> sockets;

	// Use this for initialization
	void Start () {
		Socket.timeTrial = false;
		SharedInstance = this;
		if (PlayerPrefs.GetInt ("Seed") != 0) {
			generateNewSeed = false;
			seed = PlayerPrefs.GetInt ("Seed");
		}
		if (generateNewSeed) {
			seed = Random.Range (0, int.MaxValue);
		}
		if (socketGroup != null) {
			LoadSockets ();
		}
		GetComponent<LevelDifficulty> ().PopulateValues();
		GenerateLevel ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void SaveSeed() {
		PlayerPrefs.SetInt ("Seed", seed);
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

	public int GetRandomRoomInd(Socket socket){
		return Random.Range (0, socket.roomOptions.Length);
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
		int[] roomInd = new int[sockets.Count];
		for (int i = 0; i < sockets.Count; i++) {
			roomInd [i] = Random.Range(0,sockets[i].roomOptions.Length);
		}
		for (int i = 0; i < sockets.Count; i++) {
			sockets [i].GenerateRoom (roomInd[i]);
		}
		for (int i = 0; i < sockets.Count; i++) {
			sockets [i].GenerateDoors ();
		}
		TrapPopulation trapPop = GetComponent<TrapPopulation> ();
		if (trapPop != null && trapPop.isActiveAndEnabled) {
			trapPop.GenerateTraps (seed);
		}
		EnemyPopulation enemyPop = GetComponent<EnemyPopulation> ();
		if (enemyPop != null && enemyPop.isActiveAndEnabled) {
			enemyPop.GenerateEnemies (seed);
		}
		CameraPopulation camPop = GetComponent<CameraPopulation> ();
		if (camPop != null && camPop.isActiveAndEnabled) {
			camPop.GenerateCameras (seed);
		}
		GetComponent<ObjectiveGeneration> ().ChooseObjective (seed);
	}

	public void RespawnKeycard() {
		GetComponent<ObjectiveGeneration> ().GenerateKeycard();
	}

	public void RespawnObjectiveItem() {
		GetComponent<ObjectiveGeneration> ().GenerateObjectiveItem();
	}
}
