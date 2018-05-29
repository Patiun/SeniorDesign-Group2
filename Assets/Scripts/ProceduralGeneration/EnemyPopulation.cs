using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPopulation : MonoBehaviour {

	public int numEnemies;
	public int minPatrolSize,maxPatrolSize;
	public float minDistanceBetween,enemyHelpRadius = 35f;
	public GameObject enemyPrefab;
	public GameObject patrolGroup;
	public GameObject[] allPoints;

	private List<GameObject> usedPoints;
	private List<GameObject> unusedPoints;
	private GameObject enemyContainer;

	// Use this for initialization
	void Start () {
		Random.InitState (GameObject.Find ("LevelGenerator").GetComponent<LevelGeneration> ().seed);
		//unusedPoints = new List<GameObject> (allPoints);
		//usedPoints = new List<GameObject> ();
		//enemyContainer = new GameObject ("Enemies");
		//GenerateEnemies ();
	}

	public void LoadPatrols() {
		int childCount = patrolGroup.transform.childCount;
		allPoints = new GameObject[childCount];
		for (int i = 0; i < childCount; i++) {
			GameObject child = patrolGroup.transform.GetChild (i).gameObject;
			PatrolPoint point = child.GetComponent<PatrolPoint> ();
			if (point != null) {
				allPoints [i] = child;
			}
		}
	}

	public void GenerateEnemies(int seed) {
		Random.InitState (seed);
		if (patrolGroup != null) {
			LoadPatrols();
		}

		LevelDifficulty levelDifficulty = GetComponent<LevelDifficulty> ();
		if (levelDifficulty != null) {
			numEnemies = levelDifficulty.numEnemies;
			minPatrolSize = levelDifficulty.minPatrolSize;
			maxPatrolSize = levelDifficulty.maxPatrolSize;
			enemyHelpRadius = levelDifficulty.enemyHelpRadius;
		}

		unusedPoints = new List<GameObject> (allPoints);
		usedPoints = new List<GameObject> ();
		enemyContainer = new GameObject ("Enemies");
		GameObject lastPoint = gameObject;
		for (int i = 0; i < numEnemies; i++) {
			int pointInd = Random.Range (0, unusedPoints.Count);
			GameObject point = allPoints [pointInd];
			if (Vector3.Distance (lastPoint.transform.position, point.transform.position) >= minDistanceBetween || unusedPoints.Count <= 3) {
				unusedPoints.RemoveAt (pointInd);
				usedPoints.Add (point);
				GameObject newEnemy = Instantiate (enemyPrefab);
				newEnemy.transform.position = point.transform.position;
				newEnemy.GetComponent<SphereCollider> ().radius = enemyHelpRadius;
				newEnemy.transform.parent = enemyContainer.transform;
				newEnemy.GetComponent<EnemyAI> ().worldState = GameObject.Find ("WorldController").GetComponent<WorldState> ();
				newEnemy.GetComponent<EnemyMovment> ().patrolPoints = GeneratePath (point);
				lastPoint = point;
			} else {
				i--;
			}
		}
	}

	public List<GameObject> GeneratePath(GameObject startingPoint) {
		List<GameObject> path = new List<GameObject> ();
		int patrolSize = Random.Range (minPatrolSize-1, maxPatrolSize-1);
		path.Add (startingPoint);
		GameObject mostRecentPoint = startingPoint;
		for (int i = 0; i < patrolSize; i++) {
			//Disabled Neighbors
			//GameObject newPoint = mostRecentPoint.GetComponent<PatrolPoint> ().GetRandomNeighbor ();
			GameObject newPoint = allPoints[Random.Range(0,allPoints.Length)];
			if (path.Count >= 2) {
				int previousInd = path.Count - 2;
				if (path [previousInd] == newPoint || path[previousInd+1] == newPoint || Vector3.Distance(path[previousInd].transform.position,newPoint.transform.position) > 50) {
					i--;
				} else {
					path.Add (newPoint);
					mostRecentPoint = newPoint;
				}
			} else {
				path.Add (newPoint);
				mostRecentPoint = newPoint;
			}
		}
		if (Vector3.Distance (path [0].transform.position, path [path.Count - 1].transform.position) > 50) {
			path.Add (path [path.Count/2]);
		}
		return path;
	}
	
	// Update is called once per frame
	void Update () {
		
	}


}
