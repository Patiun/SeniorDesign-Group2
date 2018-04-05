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
        if(cState == State.Investigate){
            if(count >= InvestigatingTime * 1000){
                cState = prevState;
                prevState = State.Investigate;
                count = 0;
            }
            else{
                count += 1;
            }
        }
        else if(cState == State.MoveTo){
            if(count >= MoveToTime * 1000){
                cState = State.Default;
                prevState = State.MoveTo;
            }
        }
        else{}
	}

	public void MinorActivity()
    {
        if(cState == State.Default){
            prevState = cState;
            SetStateInvestigate();
        }
        else if(cState == State.Investigate){
            SetStateInvestigate();
        }
        else if(cState == State.MoveTo){
            prevState = cState;
            SetStateInvestigate();
        }
        else if(cState == State.Attack){
            prevState = cState;
            cState = State.MoveTo;
        }
        else if(cState == State.Doors){
            prevState = cState;
            SetStateInvestigate();
        }
    }

    public void MajorActivity(){
        worldState.state = WorldState.State.Alert;

        if(isAlone == true){
            CallForBackup();
            hasCalled = true;
        }

        if(cState == State.Default){
            prevState = cState;
            cState = State.MoveTo;
        }
        else if(cState == State.Investigate){
            prevState = cState;
            cState = State.MoveTo;
        }
        else if (cState == State.MoveTo)
        {
            prevState = cState;
            SetStateInvestigate();
        }
        else if(cState == State.Attack){
            prevState = cState;
            SetStateInvestigate();
        }
        else if (cState == State.Doors)
        {
            prevState = cState;
            SetStateInvestigate();
        }
        else{}
        count = 0;
    }

    public void CalledForBackup(){
        prevState = cState;
        cState = State.MoveTo;
        count = 0;
    }

    public void CallForBackup(){
        
    }

    public void NearDoor(){
        if (cState == State.Default)
        {
            prevState = cState;
            cState = State.Doors;
        }
        else if (cState == State.MoveTo){
            prevState = cState;
            cState = State.Doors;
        }
        else{}
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

    public void SetStateInvestigate(){
        cState = State.Investigate;
        if (worldState.state == WorldState.State.Investigating)
        {
            worldState.state = WorldState.State.Cautious;
        }
        else{
            worldState.state = WorldState.State.Investigating;
        }
    }
}

