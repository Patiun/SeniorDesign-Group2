using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyVisionDetection : MonoBehaviour {

	public EnemySight es;
	public EnemyAI aI;

	void OnTriggerEnter(Collider col) {
		if (col.tag == "Player" && !es.seesPlayer) {
			es.PlayerSweep (col.ClosestPoint(transform.position));
		}
		if (col.tag == "Interactible")
        {
            if (col.GetComponent<ObjectStrangeLocation>().needsInvestigation == true)
            {
				aI.MinorActivity(col.transform.position);
				col.GetComponent<ObjectStrangeLocation>().needsInvestigation = false;
            }
        }
	}

	void OnTriggerStay(Collider col) {
		if (col.tag == "Player"  && !es.seesPlayer) {
			es.PlayerSweep (col.ClosestPoint(transform.position));
		}
		if (col.tag == "Interactible")
        {
            if (col.GetComponent<ObjectStrangeLocation>().needsInvestigation == true)
            {
				aI.MinorActivity(col.transform.position);
                col.GetComponent<ObjectStrangeLocation>().needsInvestigation = false;
            }
        }
	}
}
