using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSpawnPoint : MonoBehaviour {

	public GameObject cameraPrefab;
	public GameObject leftSide,rightSide;
	public float angleDown = 15f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	}

	public void GenerateCamera() {
		Vector3 left = leftSide.transform.position;
		left.y = transform.position.y;
		Vector3 right = rightSide.transform.position;
		right.y = transform.position.y;
		float angle = Vector3.Angle (left-transform.position, right-transform.position);
		Debug.Log (angle);
		GameObject camera = Instantiate (cameraPrefab);
		camera.transform.parent = transform;
		camera.transform.position = transform.position;
		Quaternion rotation = Quaternion.LookRotation ((left+right)/2 - transform.position);
		rotation = Quaternion.Euler (angleDown, rotation.eulerAngles.y, rotation.eulerAngles.z);
		camera.transform.rotation = rotation;
		LookAtPlayer look = camera.GetComponent<LookAtPlayer> ();
		look.sleepRotationAngle = angle/2f;
		look.worldState = GameObject.Find ("WorldController").GetComponent<WorldState> ();
		look.SetupCamera ();
	}

	void OnDrawGizmos() {
		Gizmos.color = Color.magenta;
		Gizmos.DrawWireSphere (transform.position, 0.4f);

		Gizmos.color = Color.red;
		Gizmos.DrawSphere (leftSide.transform.position, 0.1f);
		Gizmos.DrawLine (transform.position, leftSide.transform.position);

		Gizmos.color = Color.blue;
		Gizmos.DrawSphere (rightSide.transform.position, 0.1f);
		Gizmos.DrawLine (transform.position, rightSide.transform.position);
	}
}
