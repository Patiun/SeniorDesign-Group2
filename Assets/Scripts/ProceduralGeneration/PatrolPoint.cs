using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolPoint : MonoBehaviour {

	public GameObject[] neighbors;

	void Start() {
		Random.InitState (GameObject.Find ("LevelGenerator").GetComponent<LevelGeneration> ().seed); //HANDLE SAME SAMPLING?
	}

	public GameObject GetRandomNeighbor(){
		int neighborInd = Random.Range (0, neighbors.Length);
		return neighbors [neighborInd];
	}

	public void OnDrawGizmos() {
		Gizmos.DrawSphere (transform.position, 0.1f);
	}
}
