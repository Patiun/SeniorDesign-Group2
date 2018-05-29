using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectiveGeneration : MonoBehaviour {
	public static ObjectiveGeneration SharedInstance;

	public string[] randomObjectiveTypes = new string[] {"KEYCARD_GATHER","CONFIDENTIAL_FILE"};
	public string objective;

	public GameObject keycardPrefab;
	public GameObject confidentialFilePrefab;

	private int objectiveKeycard = -1;
	private List<ObjectDropZone> used;
	private GameObject objectiveItem;

	void Start () {
		
	}

	public void ChooseObjective(int seed) {
		SharedInstance = this;
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
		used = new List<ObjectDropZone> ();
		switch (objective) {
		case "KEYCARD_GATHER":
			ObjectiveManager.Instance.AddObjective ("Find the keycard for the elevators");
			ObjectiveManager.Instance.AddObjective ("Get the Agent back to the elevators");
			GenerateKeycard ();
			break;
		case "CONFIDENTIAL_FILE":
			ObjectiveManager.Instance.AddObjective ("Find the keycard for the elevators");
			ObjectiveManager.Instance.AddObjective ("Retrieve the confidential file");
			ObjectiveManager.Instance.AddObjective ("Get the Agent back to the elevators");
			GenerateKeycard ();
			GenerateConfidentialFile ();
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
			used.Add (zone);
		} else {
			Debug.LogError ("[ERROR] NO KEYCARD");
		}
	}

	public void GenerateConfidentialFile (){
		GameObject[] spawnZones = GameObject.FindGameObjectsWithTag ("ItemSpawner");
		if (spawnZones != null && spawnZones.Length > 0) {
			int spawnerInd = Random.Range (0, spawnZones.Length);
			ObjectDropZone zone = spawnZones [spawnerInd].GetComponent<ObjectDropZone> ();
			if (!used.Contains (zone)) {
				zone.objectiveObject = confidentialFilePrefab;
				zone.DropObject ();
				used.Add (zone);
			} else {
				GenerateConfidentialFile ();
			}
		} else {
			Debug.LogError ("[ERROR] NO FILE");
		}
	}

	public void GenerateObjectiveItem() {
		GameObject[] spawnZones = GameObject.FindGameObjectsWithTag ("ItemSpawner");
		if (spawnZones != null && spawnZones.Length > 0) {
			int spawnerInd = Random.Range (0, spawnZones.Length);
			ObjectDropZone zone = spawnZones [spawnerInd].GetComponent<ObjectDropZone> ();
			if (!used.Contains (zone)) {
				zone.objectiveObject = objectiveItem;
				zone.DropObject ();
				used.Add (zone);
			} else {
				GenerateObjectiveItem();
			}
		} else {
			Debug.LogError ("[ERROR] NO OBJECTIVE");
		}
	}
}
