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
	public LayerMask _mask;
	public float _DetectionDistance = 6f;
	public float _SleepRotationAngle = 30f;

	private Quaternion start_rotation;
	private float targetRotationY;
	private Camera_state state = Camera_state.ASLEEP;
	private WorldAIHandler worldAIHandler;

	RaycastHit hit;

	void Start() {
		worldAIHandler = GameObject.FindObjectOfType<WorldAIHandler> ();
	}

	void OnEnable() {
		start_rotation = transform.rotation;
		Debug.Log(transform.rotation.eulerAngles);
		targetRotationY = _SleepRotationAngle;
	}

	// Update is called once per frame
	void Update () {
//		Debug.Log (state);
		Debug.DrawRay (transform.position, (Player.position - transform.position).normalized * _DetectionDistance, Color.red);
		Physics.Raycast (transform.position, (Player.position - transform.position), out hit, _DetectionDistance, _mask);
		if (hit.collider != null && hit.collider.gameObject.Equals (Player.gameObject)){
			if (state != Camera_state.FOLLOWING && state != Camera_state.WAKING_UP) {
				StartCoroutine (WakeUp ());
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
			transform.rotation = Quaternion.Lerp (transform.rotation, Quaternion.LookRotation(Player.position - transform.position), Time.deltaTime);
			worldAIHandler.AlertEnemies (Player.position);
		}
	}

	private IEnumerator WakeUp() {
		state = Camera_state.WAKING_UP;
		yield return new WaitForSeconds (LookDelay);
		state = Camera_state.FOLLOWING;
	} 

	void OnDrawGizmos() {
		if (hit.point != null) {
			Gizmos.color = Color.yellow;
			Gizmos.DrawSphere (hit.point, .2f);
		}
	}
}
