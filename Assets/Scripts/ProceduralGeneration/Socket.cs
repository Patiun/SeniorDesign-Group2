using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Socket : MonoBehaviour {

	public GameObject[] roomOptions;
	public float[] rotationOptions;

	public bool canBeRotated;
	public GameObject room;
	private GameObject projection;

	// Use this for initialization
	void Start () {
		//Random.InitState (GameObject.Find ("LevelGenerator").GetComponent<LevelGeneration> ().seed);
		if (rotationOptions.Length <= 0) {
			canBeRotated = false;
		}

		projection = transform.GetChild (0).gameObject;
		//GenerateRoom ();
	}

	public void GenerateRoom() {
		if (projection == null) {
			projection = transform.GetChild (0).gameObject;
		}
		projection.SetActive (false);
		int roomInd = Random.Range (0, roomOptions.Length);
		GameObject newRoom = Instantiate (roomOptions [roomInd]);
		newRoom.transform.position = transform.position;
		newRoom.transform.parent = transform;
		if (canBeRotated) {
			int rotationInd = Random.Range (0, rotationOptions.Length);
			Vector3 newDir = transform.rotation.eulerAngles;
			newDir.y += rotationOptions [rotationInd];
			Quaternion newRotation = Quaternion.Euler (newDir);
			newRoom.transform.rotation = newRotation;
		} else {
			newRoom.transform.rotation = transform.rotation;
			//newRoom.transform.localScale = new Vector3 (1, 1, 1);
		}
		room = newRoom;
	}

	public void Reset() {
		room.SetActive (false);
		projection.SetActive (true);
	}
}
