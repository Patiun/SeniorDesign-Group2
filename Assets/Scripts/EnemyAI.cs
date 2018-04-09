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
    public float MoveToTime = 1;

    public int count = 0;

	public GameObject investigate_prefab;
	private Vector3 targetLocation;
	private EnemyMovment movement;

	void Start(){
		movement = GetComponent<EnemyMovment> ();
        cState = State.Default;
		movement.ReturnToPatrol (); //Start Patroling
        prevState = cState;
	}

	void Update(){
        switch (cState){
			case State.Investigate:
				if (movement.isStopped) {
					if (count >= InvestigatingTime * 1000) {
						cState = prevState;
						prevState = State.Investigate;
						if (cState == State.Default) {
							movement.ReturnToPatrol ();
						}
						count = 0;
					} else {
						count += 1;
					}
				}
                break;
            case State.MoveTo:
				if (movement.isStopped){
                    cState = State.Default;
                    prevState = State.MoveTo;
					movement.ReturnToPatrol ();
                }
                break;
            default:
                break;
        }

		//DEBUG STUFF
		if (Input.GetMouseButtonDown (0)) {
			targetLocation = Camera.main.ScreenToWorldPoint (Input.mousePosition);
			targetLocation.y = 0;
			MajorActivity ();
		}

		if (Input.GetMouseButtonDown (1)) {
			targetLocation = Camera.main.ScreenToWorldPoint (Input.mousePosition);
			targetLocation.y = 0;
			GameObject invest = Instantiate (investigate_prefab);
			invest.transform.position = targetLocation;
			MinorActivity ();
		}
	}

	public void MinorActivity()
    {
        worldState.MinorActivity();
        switch (cState){
			case State.Investigate:
				movement.InvestigateLocation (targetLocation);
                cState = State.Investigate;
                break;
            case State.MoveTo:
				movement.InvestigateLocation (targetLocation);
                prevState = cState;
                cState = State.Investigate;
                break;
			case State.Attack:
				prevState = cState;
				cState = State.MoveTo;
				movement.MoveTo (targetLocation); //targetLocation needs to be set to the player
                break;
            case State.Doors:
				movement.InvestigateLocation (targetLocation);
                prevState = cState;
                cState = State.Investigate;
                break;
            default:
				movement.InvestigateLocation (targetLocation);
                prevState = cState;
                cState = State.Investigate;
                break;
        }
    }

    public void MajorActivity(){
        worldState.MajorActivity();

        if(isAlone == true && !hasCalled){
            CallForBackup();
            hasCalled = true;
        }

        switch(cState){
			case State.Investigate:
				prevState = cState;
				cState = State.MoveTo;
				movement.MoveTo (targetLocation);
                break;
            case State.MoveTo:
				movement.InvestigateLocation (targetLocation);
                prevState = cState;
                cState = State.Investigate;
                break;
            case State.Attack:
				movement.InvestigateLocation (targetLocation);
                prevState = cState;
                cState = State.Investigate;
                break;
            case State.Doors:
				movement.InvestigateLocation (targetLocation);
                prevState = cState;
                cState = State.Investigate;
                break;
			default:
				movement.MoveTo (targetLocation);
                prevState = cState;
                cState = State.MoveTo;
                break;
        }
    }

    public void CalledForBackup(){
        prevState = cState;
        cState = State.MoveTo;
		movement.MoveTo (targetLocation); //Need to get the callers location
        count = 0;
    }

    public void CallForBackup(){
        
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

    public void SpottedPlayer(){
        prevState = cState;
        cState = State.Attack;
        count = 0;
    }

    public State GetState(){
        return cState;
    }
}

