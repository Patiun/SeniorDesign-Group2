using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldAIHandler : MonoBehaviour {

	private WorldState world;
	public List<EnemyAI> enemies;

	// Use this for initialization
	void Start () {
		world = GetComponent<WorldState> ();

		GameObject[] ei = GameObject.FindGameObjectsWithTag ("Enemy");
		foreach (GameObject enemy in ei) {
			enemies.Add (enemy.GetComponent<EnemyAI> ());
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void AlertEnemies(Vector3 AlertLocation) {
		world.MajorActivity ();
		foreach (EnemyAI enemy in enemies) {
			enemy.MajorActivity (AlertLocation);
		}
	}
}
