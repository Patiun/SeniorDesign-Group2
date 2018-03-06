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

	private Quaternion start_rotation;
	private Camera_state state = Camera_state.ASLEEP;

	RaycastHit hit;

	void Start() {
		start_rotation = transform.rotation;
	}

	// Update is called once per frame
	void Update () {
		if (Following) {
			Debug.DrawRay (transform.position, (Player.position - transform.position).normalized * _DetectionDistance, Color.red);
			Physics.SphereCast (transform.position, .2f, (Player.position - transform.position), out hit, _DetectionDistance, _mask);
			if (hit.collider != null && hit.collider.gameObject.Equals (Player.gameObject)) {
				if (state == Camera_state.ASLEEP) {
					Debug.Log (gameObject.name + " can see Player");
					StartCoroutine (WakeUp ());
				} else if (state == Camera_state.FOLLOWING) {
					// https://forum.unity.com/threads/lookat-slerp.63353/
					transform.rotation = Quaternion.Slerp (transform.rotation, Quaternion.LookRotation (Player.position - transform.position), Time.deltaTime);
				}
			} else {
				if (state == Camera_state.ASLEEP) {
					transform.rotation = Quaternion.Slerp (transform.rotation, start_rotation, Time.deltaTime);
				} else {
					state = Camera_state.ASLEEP;
				}
			}
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
