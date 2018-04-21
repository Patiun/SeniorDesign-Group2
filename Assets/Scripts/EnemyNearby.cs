using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyNearby : MonoBehaviour {

	public List<GameObject> nearbyAllies;
	public int aloneThreshold = 5;
	public bool isAlone;
	public float friendShareDistance = 3;

	// Use this for initialization
	void Start () {
		nearbyAllies = new List<GameObject> ();
	}
	
	// Update is called once per frame
	void Update () {
		isAlone = nearbyAllies.Count >= aloneThreshold;
	}

	public void Call(Vector3 target) {
		foreach (GameObject ally in nearbyAllies) {
			ally.GetComponent<EnemyAI>().CalledForBackup (target);
		}
	}

	public void OnTriggerEnter(Collider col) {
		if (col.tag == "Enemy") {
			nearbyAllies.Add(col.gameObject);
		}
	}

	public void OnTriggerExit(Collider col) {
		if (col.tag == "Enemy") {
			nearbyAllies.Remove(col.gameObject);
		}
	}

	public void ShareWithFriends(GameObject sharedTarget) {
		foreach (GameObject ally in nearbyAllies) {
			if (Vector3.Distance (transform.position, ally.transform.position) <= friendShareDistance) {
				ally.GetComponent<EnemyAI>().JoinAttackWithFriends (sharedTarget);
			}
		}
	}
}
