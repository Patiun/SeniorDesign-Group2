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

	void Start(){
        cState = State.Default;
        prevState = cState;
	}

	void Update(){
        switch (cState){
            case State.Investigate:
                if (count >= InvestigatingTime * 1000){
                    cState = prevState;
                    prevState = State.Investigate;
                    count = 0;
                }
                else{
                    count += 1;
                }
                break;
            case State.MoveTo:
                if (count >= MoveToTime * 1000){
                    cState = State.Default;
                    prevState = State.MoveTo;
                }
                break;
            default:
                break;
        }
	}

	public void MinorActivity()
    {
        worldState.MinorActivity();
        switch (cState){
            case State.Investigate:
                cState = State.Investigate;
                break;
            case State.MoveTo:
                prevState = cState;
                cState = State.Investigate;
                break;
            case State.Attack:
                prevState = cState;
                cState = State.MoveTo;
                break;
            case State.Doors:
                prevState = cState;
                cState = State.Investigate;
                break;
            default:
                prevState = cState;
                cState = State.Investigate;
                break;
        }
    }

    public void MajorActivity(){
        worldState.MajorActivity();

        if(isAlone == true){
            CallForBackup();
            hasCalled = true;
        }

        switch(cState){
            case State.Investigate:
                prevState = cState;
                cState = State.MoveTo;
                break;
            case State.MoveTo:
                prevState = cState;
                cState = State.Investigate;
                break;
            case State.Attack:
                prevState = cState;
                cState = State.Investigate;
                break;
            case State.Doors:
                prevState = cState;
                cState = State.Investigate;
                break;
            default:
                prevState = cState;
                cState = State.MoveTo;
                break;
        }
    }

    public void CalledForBackup(){
        prevState = cState;
        cState = State.MoveTo;
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

