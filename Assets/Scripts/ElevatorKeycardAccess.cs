using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorKeycardAccess : MonoBehaviour {

	public bool engaged;
	public bool hacked = true; //Have use hacking or real version
	public GameObject leftDoor,rightDoor;
	public float openSpeed;
	private float difference = 2.0f;
	private Vector3 leftTarget, leftStart, rightTarget, rightStart;
	// Use this for initialization
	void Start () {
		leftTarget = leftDoor.transform.position + leftDoor.transform.right * -difference;
		rightTarget = rightDoor.transform.position + rightDoor.transform.right*difference;
		leftStart = leftDoor.transform.position;
		rightStart = rightDoor.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		if (engaged && hacked) {
			leftDoor.transform.position = Vector3.Lerp (leftDoor.transform.position, leftTarget, Time.deltaTime * openSpeed);
			rightDoor.transform.position = Vector3.Lerp (rightDoor.transform.position, rightTarget, Time.deltaTime * openSpeed);
		} else {
			leftDoor.transform.position = Vector3.Lerp (leftDoor.transform.position, leftStart, Time.deltaTime * openSpeed);
			rightDoor.transform.position = Vector3.Lerp (rightDoor.transform.position, rightStart, Time.deltaTime * openSpeed);
		}
	}

	void OnTriggerEnter(Collider col) {
		if (col.tag == "Keycard") {
			engaged = true;
		}
	}

	void OnTriggerExit(Collider col) {
		if (col.tag == "Keycard") {
			engaged = false;
		}
	}
}
