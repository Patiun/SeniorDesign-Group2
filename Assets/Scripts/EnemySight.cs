using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySight : MonoBehaviour {

	public float sightRange;
	public float sightRadius;
	public float turnSpeed;
	public LayerMask layerMask;

	public int direction = -1;
	public float anglesElapsed = 0;
	public float angleIteration = 60;
	public float targetAngle = 60;
	public float countSweeps = 1;
	public float maxSweeps = 3;
	public float pivotRange = 15;

	private int start_direction;
	private float start_anglesElapsed,start_angleIteration,start_targetAngle,start_countSweeps,start_maxSweeps ,start_pivotRange;

	private EnemyAI eai;

	// Use this for initialization
	void Start () {
		eai = GetComponent<EnemyAI> ();
		start_direction = direction;
		start_anglesElapsed = anglesElapsed;
		start_angleIteration =angleIteration;
		start_targetAngle = targetAngle;
		start_countSweeps = countSweeps;
		start_maxSweeps = maxSweeps;
		start_pivotRange = pivotRange;
	}
	
	// Update is called once per frame
	void Update () {
		RaycastHit hit;
		//Debug.DrawRay(transform.position,transform.forward*sightRange,Color.white);
		if (Physics.SphereCast(transform.position,sightRadius,transform.forward,out hit,sightRange,layerMask.value)){
			Debug.DrawRay(transform.position,transform.forward*hit.distance,Color.yellow);
			if (hit.collider.gameObject.tag == "Player") {
				Debug.DrawRay(transform.position,transform.forward*hit.distance,Color.green);
				eai.SpottedPlayer (hit);
			}
		}
	}

	public bool LookAt(GameObject target) {
		transform.LookAt (target.transform.position);
		RaycastHit hit;
		if (Physics.Raycast (transform.position, transform.forward,out hit, sightRange, layerMask)) {
			if (hit.collider.tag == "Player") {
				return true;
			} else {
				return false;
			}
		}
		return false;
	}

	public void ResetInvestigation() {
		if (Time.time % 2 == 0) {
			start_direction *= -1;
		}
		direction = start_direction;
		anglesElapsed = start_anglesElapsed;
		targetAngle = start_targetAngle;
		countSweeps = start_countSweeps;
	}

	public void Investigate() {
		if (countSweeps <= maxSweeps) {
			if (anglesElapsed < targetAngle) {
				float angle = Time.deltaTime * turnSpeed;
				anglesElapsed += angle;
				transform.RotateAround (transform.position, transform.up, direction*angle);
			} else {
				countSweeps++;
				direction *= -1;
				targetAngle = countSweeps * angleIteration;
				anglesElapsed = 0;
			}
		} else {
			//direction *= -1;
			anglesElapsed = 0;
			countSweeps = 1;
			targetAngle = countSweeps * angleIteration;
			//float pivotAngle = Random.Range (-pivotRange, pivotRange);
			//transform.RotateAround (transform.position, transform.up, pivotAngle);
		}
	}
}
