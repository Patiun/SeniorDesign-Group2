using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectiveGeneration : MonoBehaviour {

	public string[] objectiveTypes = new string[] {"KEYCARD_GATHER"};
	public string objective;

	public GameObject keycardPrefab;

	private int objectiveKeycard = -1;

	void Start () {
		
	}

	public void ChooseObjective(int seed) {
		Random.InitState (seed);
		int objectiveInd = Random.Range (0, objectiveTypes.Length);
		objective = objectiveTypes [objectiveInd];
		PopulateObjective ();
	}

	public void PopulateObjective() {
		switch (objective) {
		case "KEYCARD_GATHER":
			GenerateKeycard ();
			//Pass Objective to Canvas
			break;
		default:
			break;
		}
	}

	public void GenerateKeycard() {
		//ObjectiveManager.Instance.AddObjective ("Find Keycard");
		GameObject[] spawnZones = GameObject.FindGameObjectsWithTag ("ItemSpawner");
		if (spawnZones != null && spawnZones.Length > 0) {
			int spawnerInd = Random.Range (0, spawnZones.Length);
			ObjectDropZone zone = spawnZones [spawnerInd].GetComponent<ObjectDropZone> ();
			zone.objectiveObject = keycardPrefab;
			zone.DropObject ();
		} else {
			Debug.LogError ("[ERROR] NO KEYCARD");
		}
	}
}
