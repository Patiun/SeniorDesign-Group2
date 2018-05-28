using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyVisionDetection : MonoBehaviour {

	public EnemySight es;
	public EnemyAI aI;

	void OnTriggerEnter(Collider col) {
		if (col.tag == "Player" && !es.seesPlayer) {
			es.GetPlayer (col.gameObject);
		}
		if (col.tag == "Interactible")
		{
			ObjectStrangeLocation strangeLocation = col.GetComponent<ObjectStrangeLocation> ();
			if (strangeLocation != null) {
				if (strangeLocation.needsInvestigation == true) {
					aI.MinorActivity (col.transform.position);
					strangeLocation.needsInvestigation = false;
				}
			}
		}
	}

	void OnTriggerExit(Collider col) {
		if (col.tag == "Player"  && !es.seesPlayer) {
			es.LosePlayer (col.gameObject);
		}
	}
}
