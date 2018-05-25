using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorSpawner : MonoBehaviour {

	public GameObject doorPrefab;
	public LayerMask obstacleLayers;
	public bool hasObject;

	public void SpawnDoor() {
		if (!Physics.CheckBox (transform.position, (new Vector3 (1f, 2f, 1.5f)) * 1f / 2f, transform.rotation, obstacleLayers.value)) {
			GameObject door = Instantiate (doorPrefab);
			door.transform.position = transform.position;
			door.transform.rotation = transform.rotation;
			door.transform.parent = transform;
		} else {
			hasObject = true;
		}
	}

	public void OnDrawGizmos() {
		Gizmos.color = Color.blue;
		Gizmos.DrawWireCube (transform.position,Quaternion.AngleAxis(transform.rotation.eulerAngles.y,transform.up) * (new Vector3 (2f, 2.75f, 1f)));
		Gizmos.color = Color.red;
		Gizmos.DrawWireCube (transform.position,Quaternion.AngleAxis(transform.rotation.eulerAngles.y,transform.up) * (new Vector3 (1.1f, 2f, 1f)));
	}
}
