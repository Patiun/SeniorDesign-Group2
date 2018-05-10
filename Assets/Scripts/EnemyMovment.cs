using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovment : MonoBehaviour {

	public bool isPatrolling = true; 
	public List<GameObject> patrolPoints;
	public Vector3 curTargetLocation;
	public int curPatrolTarget = 0;
	public float closeEnough = 0.1f;
	public float remaining = 0.0f;
	public bool isStopped;
	public float targetVariance = 2f;

	private UnityEngine.AI.NavMeshAgent nav;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		remaining = nav.remainingDistance;
		if (remaining <= closeEnough) {
			if (isPatrolling) {
				AdvancePatrol ();
			} else {
				if (!isStopped) {
					isStopped = true;
					nav.isStopped = true;
					//Debug.Log ("[DEBUG] Navmesh is stopped");
				}
			}
		} else {
			if (isStopped) {
				nav.isStopped = false;
				isStopped = false;
			}
		}

		//DEBUG STUFF

		if (Input.GetKeyDown("space")) {
			ReturnToPatrol ();
		}
	}

	void AdvancePatrol() {
		curPatrolTarget += 1;
		if (curPatrolTarget >= patrolPoints.Count) {
			curPatrolTarget = 0;
		}
		nav.SetDestination (patrolPoints [curPatrolTarget].transform.position);

	}

	public void ReturnToPatrol() {
		if (nav == null) {
			nav = GetComponent<UnityEngine.AI.NavMeshAgent> ();
		}
		isPatrolling = true;
		float minDistance = float.MaxValue;
		int targetPointIndex = 0;
		for(int i  = 0; i < patrolPoints.Count;i++){
			nav.SetDestination (patrolPoints[i].transform.position);
			float distance = nav.remainingDistance;
			if (distance <= minDistance) {
				minDistance = distance;
				targetPointIndex = i;
			}
		}
		curPatrolTarget = targetPointIndex;
		nav.SetDestination (patrolPoints [targetPointIndex].transform.position);
	}

	public void MoveTo(Vector3 target) {
		if (nav.isStopped) {
			nav.isStopped = false;
		}
		curTargetLocation = target;
		float dX = Random.Range (-targetVariance, targetVariance);
		float dZ = Random.Range (-targetVariance, targetVariance);
		curTargetLocation.x += dX;
		curTargetLocation.z += dZ;
		curTargetLocation.y = transform.position.y;
		isPatrolling = false;
		nav.SetDestination (curTargetLocation);
		if (nav.pathStatus == UnityEngine.AI.NavMeshPathStatus.PathInvalid) {
			MoveTo (target);
		}
	}

	public bool MoveInRange(Vector3 target, float range) {
		nav.SetDestination (target);
		if (nav.remainingDistance <= range) {
			nav.isStopped = true;
			nav.SetDestination(transform.position);
			return true;
		}
		return false;
	}

	public void InvestigateLocation(Vector3 target) {
		MoveTo (target);
	}

}
