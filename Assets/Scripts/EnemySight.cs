using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySight : MonoBehaviour {

	public float sightRange;
	public float sightRadius;
	public float turnSpeed;
	public LayerMask layerMask;

	public float timeToSpotPlayer;
	private float originalTimeToSpotPlayer;
	public float timeSeeingPlayer = 0.0f;
	public bool seesPlayer = false;

	public int direction = -1;
	public float degreesPerSecond = 30;

	private int start_direction;
	private float start_anglesElapsed,start_angleIteration,start_targetAngle,start_countSweeps,start_maxSweeps ,start_pivotRange;

	private EnemyAI eai;

	RaycastHit hit;

	// Use this for initialization
	void Start () {
		eai = GetComponent<EnemyAI> ();
		start_direction = direction;
		timeToSpotPlayer = eai.GetDetectionTime ();
		originalTimeToSpotPlayer = timeToSpotPlayer;
	}
	
	// Update is called once per frame
	void Update () {
		timeToSpotPlayer = eai.GetDetectionTime ();
		if (seesPlayer) {
			timeSeeingPlayer += Time.deltaTime;
			if (timeSeeingPlayer >= timeToSpotPlayer) {
				eai.SpottedPlayer (hit);
				timeSeeingPlayer = 0;
			}
		} else {
			if (eai.lostPlayerTime <= eai.lockOnTime) {
				eai.lostPlayerTime += Time.deltaTime;
			}
		}
	}

	public void PlayerSweep(Vector3 player) {
		//RaycastHit hit;
		//Debug.DrawRay(transform.position,transform.forward*sightRange,Color.white);
		if (Physics.SphereCast(transform.position,sightRadius * timeToSpotPlayer/originalTimeToSpotPlayer,player-transform.position,out hit,Mathf.Infinity,layerMask.value)){
			Debug.DrawRay(transform.position,(player-transform.position)*hit.distance,Color.yellow);
			if (hit.collider.gameObject.tag == "Player") {
				Debug.DrawRay (transform.position, (player - transform.position) * hit.distance, Color.green);
				seesPlayer = true;
				eai.lostPlayerTime = 0;
				//eai.SpottedPlayer (hit);
			} else {
				seesPlayer = false;
				timeSeeingPlayer = 0;
			}
		}
	}

	public bool LookAt(GameObject target) {
		Vector3 targetPosition = target.GetComponent<Collider> ().ClosestPoint (transform.position);
		transform.LookAt (targetPosition);
		//RaycastHit hit;
		if (Physics.Raycast (transform.position, transform.forward,out hit, sightRange, layerMask.value)) {
			if (hit.collider.tag == "Player") {
				return true;
			} else {
				return false;
			}
		}
		return false;
	}

	public void PlayerNearby(Vector3 player) {
		//RaycastHit hit;
		Debug.DrawRay (transform.position, player - transform.position, Color.cyan);
		if (Physics.SphereCast(transform.position,sightRadius* timeToSpotPlayer/originalTimeToSpotPlayer,player-transform.position,out hit,Mathf.Infinity,layerMask.value)) {
			if (hit.collider.tag == "Player") {
				transform.LookAt (player);
			}
		}
	}

	public void ResetInvestigation() {
		if (Time.time % 2 == 0) {
			start_direction *= -1;
		}
		direction = start_direction;
	}

	public void Investigate() {
		//!!!!!!!!!!!!!! LERP HERE !!!!!!!!!!!!!!!!!!!
//		if (countSweeps <= maxSweeps) {
//			if (anglesElapsed < targetAngle) {
//				float angle = Time.deltaTime * turnSpeed;
//				anglesElapsed += angle;
//				transform.RotateAround (transform.position, transform.up, direction*angle);
//			} else {
//				countSweeps++;
//				direction *= -1;
//				targetAngle = countSweeps * angleIteration;
//				anglesElapsed = 0;
//			}
//		} else {
//			//direction *= -1;
//			anglesElapsed = 0;
//			countSweeps = 1;
//			targetAngle = countSweeps * angleIteration;
//			//float pivotAngle = Random.Range (-pivotRange, pivotRange);
//			//transform.RotateAround (transform.position, transform.up, pivotAngle);
//		}

		Vector3 angles = transform.eulerAngles;
		angles.y += direction*degreesPerSecond*Time.deltaTime;
		Quaternion newRotation = Quaternion.Euler (angles);
		transform.rotation = Quaternion.Slerp (transform.rotation, newRotation, 10);
	}

	void OnDrawGizmos() {
		if (hit.point != null) {
			Gizmos.color = Color.yellow;
			Gizmos.DrawSphere (hit.point, sightRadius* timeToSpotPlayer/originalTimeToSpotPlayer);
		}
	}
}
