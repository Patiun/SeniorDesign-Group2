using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPopulation : MonoBehaviour {

	public int numCameras;
	public GameObject cameraGroup; 
	public CameraSpawnPoint[] cameraPoints;

	private List<CameraSpawnPoint> used, unused;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}

	public void LoadCameraGroup() {
		int childCount = cameraGroup.transform.childCount;
		cameraPoints = new CameraSpawnPoint[childCount];
		for (int i = 0; i < childCount; i++) {
			GameObject child = cameraGroup.transform.GetChild (i).gameObject;
			CameraSpawnPoint point = child.GetComponent<CameraSpawnPoint> ();
			if (point != null) {
				cameraPoints [i] = point;
			}
		}
	}

	public void GenerateCameras(int seed) {
		Random.InitState (seed);
		/*Depricated
		if (cameraGroup != null) {
			LoadCameraGroup ();
		}*/
		GameObject[] points = GameObject.FindGameObjectsWithTag ("CameraSpawner");
		cameraPoints = new CameraSpawnPoint[points.Length];
		for (int i = 0; i < points.Length; i++) {
			cameraPoints [i] = points [i].GetComponent<CameraSpawnPoint> ();
		}

		LevelDifficulty levelDifficulty = GetComponent<LevelDifficulty> ();
		if (levelDifficulty != null) {
			numCameras = levelDifficulty.numCameras;
		}

		unused = new List<CameraSpawnPoint> (cameraPoints);
		used = new List<CameraSpawnPoint> ();
		for (int i = 0; i < numCameras; i++) {
			int camInd = Random.Range (0, unused.Count);
			unused [camInd].GenerateCamera ();
			used.Add (unused [camInd]);
			unused.RemoveAt (camInd);
		}
	}
}
