using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class RollyDroneControl : MonoBehaviour {
	public Transform WheelLeft, WheelRight, BlasterBase, BlasterRod1, BlasterRod2, Axel, Body;
	public Transform BlasterBaseAngleCorrectionTransform;
	public Transform NavAgentToFollow;
	public Transform target;
	public Transform gunPoint;
	public float WheelRotation_Left, WheelRotation_Right;
	public float BlasterBaseRotation;
	public float BodyRotation;
	public float DroneRotation;
	public float DroneYOffset;
	public float BodyXOffset;
	public bool activateTargeting = false;
	Vector3 prevPosition;

	float prevYRotation = 0;
	void Update() {
		if (NavAgentToFollow != null) {
			DroneRotation = NavAgentToFollow.localRotation.eulerAngles.y;
			transform.position = NavAgentToFollow.position;
		}
		DroneRotation = DroneRotation % 360f;
		WheelRotation_Left = WheelRotation_Left % 360f;
		WheelRotation_Right = WheelRotation_Right % 360f;
		transform.localRotation = Quaternion.AngleAxis(DroneRotation + DroneYOffset, Vector3.up);
		WheelRotation_Left += (DroneRotation - prevYRotation) * 2f;
		WheelRotation_Right -= (DroneRotation - prevYRotation) * 2f;

		float DistanceRoll = Vector3.Distance(prevPosition, transform.position) * 360f;
		if (Vector3.Dot (transform.forward, transform.position - prevPosition) < 0) {
			DistanceRoll *= -1;
		}
		WheelRotation_Left += DistanceRoll;
		WheelRotation_Right += DistanceRoll;

		WheelLeft.localRotation = Quaternion.AngleAxis (WheelRotation_Left, Vector3.right);
		WheelRight.localRotation = Quaternion.AngleAxis (WheelRotation_Right, Vector3.right);
//		BlasterBase.localRotation = Quaternion.AngleAxis (BlasterBaseRotation, BlasterBaseAngleCorrectionTransform.up);
		Body.localRotation = Quaternion.AngleAxis(BodyRotation, Vector3.right);

		prevYRotation = DroneRotation;
		prevPosition = transform.position;
		if (target != null && activateTargeting) {
			LookAtPoint (target.position);
		}
	}

	public void LookAtPoint(Vector3 LookAt) {
		// Angle between floor parallel and target transform
//		float distanceToTarget = Vector3.Distance(LookAt, transform.position);
//		float floorToTargetAngle = Vector3.Angle (Vector3.forward * distanceToTarget, Vector3.forward * distanceToTarget + Vector3.up * (LookAt.y - transform.position.y));
//		BodyRotation = floorToTargetAngle + BodyXOffset;
		Vector3 destAngle = Quaternion.LookRotation(LookAt - transform.position).eulerAngles;
		BodyRotation = -destAngle.x + BodyXOffset;
//		BlasterBaseAngleCorrectionTransform.localRotation = Quaternion.Euler(
//			new Vector3(BlasterBaseAngleCorrectionTransform.localRotation.eulerAngles.x,
//			destAngle.y + 180f, 
//			BlasterBaseAngleCorrectionTransform.localRotation.eulerAngles.z)
//		);
		BlasterBase.localRotation = Quaternion.LookRotation(LookAt) * BlasterBaseAngleCorrectionTransform.localRotation;
	}
}
