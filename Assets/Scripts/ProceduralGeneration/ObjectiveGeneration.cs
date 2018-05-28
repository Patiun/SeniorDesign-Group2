using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectiveGeneration : MonoBehaviour {

	public string[] randomObjectiveTypes = new string[] {"KEYCARD_GATHER"};
	public string objective;

	public GameObject keycardPrefab;

	private int objectiveKeycard = -1;

	void Start () {
		
	}

	public void ChooseObjective(int seed) {
		if (GameObject.FindGameObjectWithTag ("TimeTrial") != null) {
			objective = "TIME_TRIAL";
		} else {
			Random.InitState (seed);
			int objectiveInd = Random.Range (0, randomObjectiveTypes.Length);
			objective = randomObjectiveTypes [objectiveInd];
			PopulateObjective ();
		}
	}

	public void PopulateObjective() {
		switch (objective) {
		case "KEYCARD_GATHER":
			ObjectiveManager.Instance.AddObjective ("Find the keycard to access the other elevator!");
			GenerateKeycard ();
			break;
		case "TIME_TRIAL":
			ObjectiveManager.Instance.AddObjective ("Get to the elevator before time runs out!");
			break;
		default:
			break;
		}
	}

	public void GenerateKeycard() {
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
