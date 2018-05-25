using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorSpawner : MonoBehaviour {

	public GameObject doorPrefab;
	public LayerMask obstacleLayers;
	public bool hasObject;

	// Use this for initialization
	void Start () {
		
	}

	void OnEnable() {
		hasObject = Physics.CheckBox (transform.position, (new Vector3 (1f, 2f, 1.5f))*1f/2f,transform.rotation, obstacleLayers.value);
	}

	public void LateUpdate() {
		if (!hasObject) {
			SpawnDoor ();
		}
	}

	public void SpawnDoor() {
		
		hasObject = true;
		Destroy (GetComponent<SphereCollider> ());
		GameObject door = Instantiate (doorPrefab);
		door.transform.position = transform.position;
		door.transform.rotation = transform.rotation;
		door.transform.parent = transform;
	}

	public void OnDrawGizmos() {
		Gizmos.color = Color.blue;
		Gizmos.DrawWireCube (transform.position,new Vector3 (1f, 2.75f, 2f));
		Gizmos.color = Color.red;
		Gizmos.DrawWireCube (transform.position,new Vector3 (1f, 2f, 1.5f));
	}
}
