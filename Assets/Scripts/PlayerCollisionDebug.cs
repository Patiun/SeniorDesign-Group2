using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisionDebug : MonoBehaviour {

	public GameObject lastHit;

	void OnTriggerEnter(Collider col) {
		if (!col.isTrigger) {
			Debug.Log ("[DEBUG] Player collided with " + col.gameObject.name);
			lastHit = col.gameObject;
		}
	}
}
