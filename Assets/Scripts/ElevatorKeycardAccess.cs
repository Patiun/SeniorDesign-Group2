using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorKeycardAccess : MonoBehaviour {

	public bool engaged;
	public bool hacked = true; //Have use hacking or real version
	public GameObject leftDoor,rightDoor;
	public float openSpeed;
	private float leftPosition,rightPosition,targetLeftPosition,targetRightPosition;
	private float difference = 2.0f;
	// Use this for initialization
	void Start () {
		leftPosition = leftDoor.transform.position.x;
		rightPosition = rightDoor.transform.position.x;
		targetLeftPosition = leftPosition + difference;
		targetRightPosition = rightPosition - difference;
	}
	
	// Update is called once per frame
	void Update () {
		if (engaged && hacked) {
			//Left Door
			if (leftDoor.transform.position.x < targetLeftPosition) {
				Vector3 newPosition = leftDoor.transform.position;
				newPosition.x += difference / openSpeed;
				leftDoor.transform.position = newPosition;
			} else if (leftDoor.transform.position.x > targetLeftPosition) {
				Vector3 newPosition = leftDoor.transform.position;
				newPosition.x = targetLeftPosition;
				leftDoor.transform.position = newPosition;
			}
			//Right Door
			if (rightDoor.transform.position.x > targetRightPosition) {
				Vector3 newPosition = rightDoor.transform.position;
				newPosition.x -= difference / openSpeed;
				rightDoor.transform.position = newPosition;
			} else if (rightDoor.transform.position.x < targetRightPosition) {
				Vector3 newPosition = rightDoor.transform.position;
				newPosition.x = targetRightPosition;
				rightDoor.transform.position = newPosition;
			}
		} else {
			//Left Door
			if (leftDoor.transform.position.x > leftPosition) {
				Vector3 newPosition = leftDoor.transform.position;
				newPosition.x -= difference / openSpeed;
				leftDoor.transform.position = newPosition;
			} else if (leftDoor.transform.position.x < leftPosition) {
				Vector3 newPosition = leftDoor.transform.position;
				newPosition.x = leftPosition;
				leftDoor.transform.position = newPosition;
			}
			//Right Door
			if (rightDoor.transform.position.x < rightPosition) {
				Vector3 newPosition = rightDoor.transform.position;
				newPosition.x += difference / openSpeed;
				rightDoor.transform.position = newPosition;
			} else if (rightDoor.transform.position.x > rightPosition) {
				Vector3 newPosition = rightDoor.transform.position;
				newPosition.x = rightPosition;
				rightDoor.transform.position = newPosition;
			}
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
