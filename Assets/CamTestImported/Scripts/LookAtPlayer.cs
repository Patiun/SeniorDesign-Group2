using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum Camera_state {
	ASLEEP,
	WAKING_UP,
	FOLLOWING
}

public class LookAtPlayer : MonoBehaviour {
	public Transform Player;
	public bool Following = true;
//	public float FollowSnapSpeedCoefficient = .2f;
	public float LookDelay = 1.5f;
	private float originalLookTime;
	public LayerMask _mask;
	public float _DetectionDistance = 6f;
	public float sleepRotationAngle;

	private Quaternion start_rotation;
	public float targetRotationY;
	private Camera_state state = Camera_state.ASLEEP;
	private WorldAIHandler worldAIHandler;
	public WorldState worldState;
	public CameraFieldOfView cameraFOV;
	private Vector3 playerLocation;

	RaycastHit hit;

	void Start() {
		worldAIHandler = GameObject.FindObjectOfType<WorldAIHandler> ();
		originalLookTime = worldState.GetDetectionTime();
	}

	public void SetupCamera() {
		start_rotation = transform.rotation;
		//Debug.Log(transform.rotation.eulerAngles);
		targetRotationY = sleepRotationAngle;
	}

	// Update is called once per frame
	void Update () {
//		Debug.Log (state);
		//INSERT COLLIDER CHECK HERE
		if (cameraFOV.hasPlayer) {
			playerLocation = cameraFOV.playerLocation;
			Debug.DrawRay (transform.position, (playerLocation - transform.position).normalized * _DetectionDistance, Color.red);
			Physics.Raycast (transform.position, (playerLocation - transform.position), out hit, _DetectionDistance, _mask.value);
			if (hit.collider != null && hit.collider.gameObject.tag == "Player") {
				if (state != Camera_state.FOLLOWING && state != Camera_state.WAKING_UP) {
					StartCoroutine (WakeUp ());
				}
			} else {
				state = Camera_state.ASLEEP;
			}
		} else {
			state = Camera_state.ASLEEP;
		}

		if (state == Camera_state.ASLEEP) {
			Quaternion targetAngle = Quaternion.AngleAxis (targetRotationY, Vector3.up) * start_rotation;
			transform.rotation = Quaternion.Lerp (transform.rotation, targetAngle, Time.deltaTime);
			if (Quaternion.Angle (targetAngle, transform.rotation) <= .05f) {
				targetRotationY *= -1;
			}
		} else if (state == Camera_state.FOLLOWING) {
			transform.rotation = Quaternion.Lerp (transform.rotation, Quaternion.LookRotation(playerLocation - transform.position), Time.deltaTime);
			worldAIHandler.AlertEnemies (playerLocation);
		}
	}

	private IEnumerator WakeUp() {
		state = Camera_state.WAKING_UP;
		yield return new WaitForSeconds (LookDelay*worldState.GetDetectionTime()/originalLookTime);
		state = Camera_state.FOLLOWING;
	} 

	void OnDrawGizmos() {
		if (hit.point != null) {
			Gizmos.color = Color.yellow;
			Gizmos.DrawSphere (hit.point, .2f);
		}
	}
}
