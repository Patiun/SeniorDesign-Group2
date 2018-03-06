using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlerpRotationFollow : MonoBehaviour {
	public float FollowSpeedCoefficient = .3f;
	public Transform TransformToFollow;

	public bool AbsoluteFollow = false;

	void Update () {
		if (AbsoluteFollow) {
			transform.rotation = TransformToFollow.rotation;
		} else {
			transform.rotation = Quaternion.Slerp (transform.rotation, TransformToFollow.rotation, FollowSpeedCoefficient);
		}
	}
}
