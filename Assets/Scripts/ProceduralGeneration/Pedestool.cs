using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pedestool : MonoBehaviour {

	public bool hasSub;
	public bool hasJewel;
	public bool alerted;
	private GameObject target;
	private GameObject sub;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (!alerted) {
			if (!(hasSub || hasJewel)) { // || (hasSub && hasJewel)
				GameObject.Find ("WorldController").GetComponent<WorldAIHandler> ().AlertEnemies (transform.position);
				alerted = true;
			}
		}
	}

	public void OnTriggerEnter(Collider col) {
		if (target == null) {
			if (col.tag == "ObjectiveItem") {
				target = col.gameObject;
				hasJewel = true;
			}
		} else {
			if (col.gameObject == target) {
				hasJewel = true;
			}
			if (!hasSub) {
				if (col.gameObject != target && col.gameObject.GetComponent<Rigidbody> ().mass == target.GetComponent<Rigidbody> ().mass) {
					hasSub = true;
					sub = col.gameObject;
				} else {
					GameObject.Find ("WorldController").GetComponent<WorldAIHandler> ().AlertEnemies (col.transform.position);
				}
			}
		}
	}

	public void OnTriggerExit(Collider col) {
		if (col.tag == "ObjectiveItem") {
			hasJewel = false;
			if (!hasSub) {
				GameObject.Find ("WorldController").GetComponent<WorldAIHandler> ().AlertEnemies (col.transform.position);
			}
		} else {
			if (hasSub && col.gameObject == sub) {
				hasSub = false;
			}
		}
	}
}
