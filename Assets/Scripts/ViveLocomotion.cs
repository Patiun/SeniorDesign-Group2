using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * Author: Greg Kilmer
 * Last Updated: 2/28/2018
 * */

public class ViveLocomotion : MonoBehaviour {

	public SteamVR_TrackedObject trackedObjLeft;
	public SteamVR_TrackedObject trackedObjRight;
	public float threshold;
	public float baseSpeed;
	public float scaling;
	public bool canWalk;

	private Rigidbody rb;

	private SteamVR_Controller.Device leftController
	{
		get { return SteamVR_Controller.Input((int)trackedObjLeft.index); }
	}

	private SteamVR_Controller.Device rightController
	{
		get { return SteamVR_Controller.Input((int)trackedObjRight.index); }
	}

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 left_velocity = leftController.velocity;
		Vector3 right_velocity = rightController.velocity;
		float left_mag = left_velocity.magnitude;
		float right_mag = right_velocity.magnitude;
		float averageSpeed = (left_mag + right_mag) / 2;
		Vector3 left_dir = left_velocity.normalized;
		Vector3 right_dir = right_velocity.normalized;

		if ((leftController.GetAxis() != Vector2.zero || rightController.GetAxis() != Vector2.zero) && averageSpeed > threshold && (Mathf.Abs(left_velocity.y) > 0.5 && Mathf.Abs(right_velocity.y) > 0.5)) {
			canWalk = true;
		} else {
			canWalk = false;
		}

		if (canWalk) {
			//Vector3 difference = transform.position + GetComponentInChildren<Camera>().transform.forward * (baseSpeed + scaling * averageSpeed) / 10.0f;
			//difference.y = 0;
			//transform.position = difference;
			Vector3 movement = GetComponentInChildren<Camera>().transform.forward * (baseSpeed + scaling * averageSpeed) / 10.0f;
			movement.y = 0;
			rb.velocity = movement;
		} else {
			rb.velocity = Vector3.zero;
		}
	}
}
