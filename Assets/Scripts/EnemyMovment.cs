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

	private UnityEngine.AI.NavMeshAgent nav;

	// Use this for initialization
	void Start () {
		nav = GetComponent<UnityEngine.AI.NavMeshAgent> ();
	}
	
	// Update is called once per frame
	void Update () {
		remaining = nav.remainingDistance;
		if (remaining <= closeEnough) {
			if (isPatrolling) {
				AdvancePatrol ();
			} else {
				isStopped = true;
				//nav.isStopped = true;
			}
		} else {
			//nav.isStopped = false;
			isStopped = false;
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
		nav.isStopped = false;
		curTargetLocation = target;
		isPatrolling = false;
		nav.SetDestination (target);
	}

	public bool MoveInRange(Vector3 target, float range) {
		nav.SetDestination (target);
		if (nav.remainingDistance <= range) {
			nav.isStopped = true;
			return true;
		}
		return false;
	}

	public void InvestigateLocation(Vector3 target) {
		MoveTo (target);
	}

}
