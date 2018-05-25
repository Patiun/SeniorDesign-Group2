using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour {
    public enum State { Default, Investigate, MoveTo, Attack, Doors };
    public WorldState worldState;

    public State cState;
    public State prevState;

    public bool isAlone;
    public bool hasCalled = false;

    public float InvestigatingTime = 1;
    public float MoveToTime = 10;
	public float followRange = 10;
	public float lockOnTime = 5f;
	public float lostPlayerTime;

    public float count = 0;

	public GameObject target;
	private Vector3 targetLocation;
	private Vector3 preInvestigateTarget;
	private State statePreInvestigate;
	private EnemyMovment movement;
	private EnemySight sight;
	private EnemyAttack weapon;
	private EnemyNearby nearby;
    
	void Start(){
		movement = GetComponent<EnemyMovment> ();
		sight = GetComponent<EnemySight> ();
		weapon = GetComponent<EnemyAttack> ();
		nearby = GetComponent<EnemyNearby> ();
        cState = State.Default;
		movement.ReturnToPatrol (); //Start Patroling
        prevState = cState;
	}

	void Update(){
		isAlone = nearby.isAlone;
        switch (cState){
			case State.Investigate:
				if (movement.isStopped) { //DO THE INVESTIGATING
					if (count >= InvestigatingTime) {
						switch (statePreInvestigate) {
							case State.Default:
								ToDefault ();
								break;
							case State.Doors:
								ToDoors ();
								break;
							case State.MoveTo:
								ToMoveTo (preInvestigateTarget);
								break;
							default:
								ToDefault ();
								break;
							}
							count = 0;
					} else {
						sight.Investigate ();
						count += Time.deltaTime;
					}
				}
                break;
            case State.MoveTo:
				if (movement.isStopped){
					if (count >= MoveToTime) {
						ToDefault ();
						count = 0;
					} else {
						count += Time.deltaTime;
					}
                }
                break;
		case State.Attack:
			//Debug.Log ("[DEBUG] Attacking " + target.gameObject.name);
			if (!sight.LookAt (target)) {
			//Debug.Log ("[DEBUG] Lost sight of player object: "+target.gameObject.name);
				float angleBetween = Vector3.Angle(transform.forward,target.transform.position-transform.position);
				if (angleBetween < 0) {
					sight.direction = -1;
				} else {
					sight.direction = 1;
				}
				sight.seesPlayer = false;
				if (lostPlayerTime < lockOnTime) {
					movement.MoveTo (target.transform.position);
				} else {
					ToInvestigate (target.transform.position);
				}
			} else {
				lostPlayerTime = 0;
				movement.MoveInRange (targetLocation, followRange);
				nearby.ShareWithFriends (target);
				weapon.HasTarget (targetLocation);
			}
			break;
            default:
                break;
        }
	}

	public void MinorActivity(Vector3 target)
    {
        worldState.MinorActivity();
        switch (cState){
			case State.Investigate:
				ToInvestigate(target);
                break;
			case State.MoveTo:
                break;
			case State.Attack:
				ToMoveTo (target);//targetLocation needs to be set to the player
                break;
			case State.Doors:
				ToInvestigate (target);
                break;
			default:
				ToInvestigate (target);
                break;
        }
    }

	public void MajorActivity(Vector3 target){
        worldState.MajorActivity();

        CallForBackup(target);

        switch(cState){
			case State.Investigate:
				ToMoveTo (target);
                break;
			case State.MoveTo:
				ToInvestigate (target);
                break;
			case State.Attack:
				ToInvestigate (target);
                break;
			case State.Doors:
				ToMoveTo (target);
                break;
			default:
				ToMoveTo (target);
                break;
        }
    }

	public void CalledForBackup(Vector3 callerLocation){
		if (cState != State.Attack) {
			ToInvestigate(callerLocation); //Need to get the callers location
			count = 0;
		}
    }

	public void CallForBackup(Vector3 target){
		nearby.Call (target);
		//Debug.Log ("HELP!");
    }

    public void NearDoor(){
        switch(cState){
            case State.MoveTo:
                prevState = cState;
                cState = State.Doors;
                break;
            default:
                prevState = cState;
                cState = State.Doors;
                break;

        }
        count = 0;
    }

	public void SpottedPlayer(RaycastHit hit){
		worldState.MajorActivity ();
		GameObject player = hit.collider.gameObject;
		target = player;

		CallForBackup(player.transform.position);

		targetLocation = player.transform.position; //hit.point;
		ToAttack ();
    }

	public void LostSightOfPlayer(Vector3 playerLocation) {
		ToInvestigate (playerLocation);
	}

	private void ToDefault() {
		if (cState != State.Default) {
			weapon.Discard ();
			prevState = cState;
			cState = State.Default;
			movement.ReturnToPatrol ();
			count = 0;
		}
	}

	private void ToMoveTo(Vector3 target) {
		if (cState != State.MoveTo) {
			targetLocation = target;
			prevState = cState;
			cState = State.MoveTo;
			movement.MoveTo (targetLocation);
			count = 0;
		}
	}

	private void ToInvestigate(Vector3 target) {
		if (cState != State.Investigate) {
			sight.ResetInvestigation ();
			preInvestigateTarget = targetLocation;
			targetLocation = target;
			prevState = cState;
			statePreInvestigate = prevState;
			cState = State.Investigate;
			movement.InvestigateLocation (targetLocation);
			count = 0;
		} else {
			sight.ResetInvestigation ();
			targetLocation = target;
			movement.InvestigateLocation (targetLocation);
			count = 0;
		}
	}

	private void ToAttack() {
		if (cState != State.Attack) {
			worldState.MajorActivity ();
			prevState = cState;
			cState = State.Attack;
			count = 0;
			movement.MoveTo (targetLocation);
		}
	}

	public void JoinAttackWithFriends(GameObject newTarget) {
		target = newTarget;
		targetLocation = target.transform.position;
		ToAttack ();
	}

	private void ToDoors() {
		if (cState != State.Doors) {
			prevState = cState;
			cState = State.Doors;
			count = 0;

		}
	}

    public State GetState(){
        return cState;
    }

	public float GetDetectionTime() {
		return worldState.GetDetectionTime ();
	}
}

