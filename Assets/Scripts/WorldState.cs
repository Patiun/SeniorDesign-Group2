using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldState : MonoBehaviour {

	public enum State {Asleep, Alert, Cautious, CoolingDown, Investigating};
	public State state;
	public State lastState;

	public float TimeUntilCooling = 1; //Time in Alert that passes with no activity to start cooling down in Seconds
	public float CoolingTime = 1; //Time it takes to cool down to cautious in Seconds
	public float InvestigateTime = 1; //Time it takes to give up on investigating and move back to Asleep, in Seconds

	public bool isAsleep;
	public bool isAlert;
	public bool isCautious;
	public bool isCoolingDown;
	public bool isInvestigating;

	//In Seconds
	public float alertDetectionTime = 0.2f;
	public float cautiousDetectionTime = 0.5f;
	public float asleepDetectioNTime = 0.8f;

	public int count = 0;
	public AudioSource alarm;

	// Use this for initialization
	void Start () {
		isAsleep = true;
		isAlert = false;
		isCautious = false;
		isCoolingDown = false;
		isInvestigating = false;
		state = State.Asleep;
		lastState = state;
	}
	
	// Update is called once per frame
	void Update () {
		if (isAlert) {
			if (!alarm.isPlaying) {
				alarm.volume = 0.8f;
				alarm.Play ();
			}
			if (count >= TimeUntilCooling*1000) {
				isAlert = false;
				isCoolingDown = true;
				lastState = state;
				state = State.CoolingDown;
				count = 0;
			} else {
				count += 1;
			}
		}
		if (isCoolingDown) {
			if (alarm.isPlaying) {
				alarm.volume = 0.3f;
				//alarm.Stop ();
			}
			if (count >= CoolingTime*1000) {
				isCoolingDown = false;
				isCautious = true;
				lastState = state;
				state = State.Cautious;
				count = 0;
			} else {
				count += 1;
			}
		}
		if (isCautious || isAsleep) {
			if (alarm.isPlaying) {
				alarm.Stop ();
			}
		}
		if (isInvestigating) {
			if (count >= InvestigateTime*1000) {
				isInvestigating = false;
				state = lastState;
				lastState = State.Investigating;
				//state = State.Cautious;
				count = 0;
			} else {
				count += 1;
			}
		}
	}

	public void MajorActivity() {
		isAsleep = false;
		isCautious = false;
		isCoolingDown = false;
		isInvestigating = false;
		isAlert = true;
		count = 0;
		lastState = state;
		state = State.Alert;
	}

	public void MinorActivity() {
		if (isAsleep) {
			isAsleep = false;
			isCautious = false;
			isCoolingDown = false;
			isInvestigating = true;
			isAlert = false;
			lastState = state;
			state = State.Investigating;
		} else if (isCautious) {
			isAsleep = false;
			isCautious = false;
			isCoolingDown = false;
			isInvestigating = true;
			isAlert = false;
			lastState = state;
			state = State.Investigating;
		}
	}

	//DEBUG ONLY
	public void Reset() {
		isAsleep = true;
		isAlert = false;
		isCautious = false;
		isCoolingDown = false;
		isInvestigating = false;
		state = State.Asleep;
		lastState = state;
		alarm.Stop ();
		count = 0;
	}

	public State GetState() {
		return state;
	}

	public float GetDetectionTime() {
		switch (state) {
		case State.Alert:
			return alertDetectionTime;
		case State.Cautious:
			return cautiousDetectionTime;
		case State.Asleep:
			return asleepDetectioNTime;
		default:
			return asleepDetectioNTime;
		}
	}

}
