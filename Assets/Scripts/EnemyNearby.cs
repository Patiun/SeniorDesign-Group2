using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyNearby : MonoBehaviour {

	public List<EnemyAI> nearbyAllies;
	public int aloneThreshold = 5;
	public bool isAlone;

	// Use this for initialization
	void Start () {
		nearbyAllies = new List<EnemyAI> ();
	}
	
	// Update is called once per frame
	void Update () {
		isAlone = nearbyAllies.Count >= aloneThreshold;
	}

	public void Call(Vector3 target) {
		foreach (EnemyAI ally in nearbyAllies) {
			ally.CalledForBackup (target);
		}
	}

	public void OnTriggerEnter(Collider col) {
		if (col.tag == "Enemy") {
			nearbyAllies.Add(col.gameObject.GetComponent<EnemyAI>());
		}
	}

	public void OnTiggerExit(Collider col) {
		if (col.tag == "Enemy") {
			nearbyAllies.Remove (col.gameObject.GetComponent<EnemyAI> ());
		}
	}
}
