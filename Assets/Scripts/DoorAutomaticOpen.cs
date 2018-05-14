using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorAutomaticOpen : MonoBehaviour {

	public Door door;
	public List<string> accepted;
	private ObjectStrangeLocation locationLogic;

	// Use this for initialization
	void Start () {
		locationLogic = GetComponent<ObjectStrangeLocation> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void OnTriggerEnter(Collider col) {
		if (accepted.Contains(col.gameObject.tag) && !col.isTrigger) {
			door.Open();
		}
	}

	public void OnTriggerStay(Collider col) {
		if (accepted.Contains(col.gameObject.tag) && !col.isTrigger) {
			door.Open();
		}
	}

	public void OnTriggerExit(Collider col) {
		if (accepted.Contains(col.gameObject.tag) && !col.isTrigger) {
			//Debug.Log ("Enemy Left");
			door.Close();
			//locationLogic.lastPosition = door.gameObject.transform.position;
		}
	}
}
