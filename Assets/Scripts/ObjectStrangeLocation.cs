using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectStrangeLocation : MonoBehaviour {
	public float maximumSafeDistance;

	public bool needsInvestigation;

	private Vector3 currentPosition;
	private Vector3 lastPosition;
	private Vector3 startingPosition;

	// Use this for initialization
	void Start () {
		needsInvestigation = false;
		currentPosition = transform.position;
		lastPosition = currentPosition;
		startingPosition = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void OnCollisionEnter(Collision collision){
		currentPosition = transform.position;
		if(Mathf.Abs(Vector3.Distance(currentPosition, lastPosition)) > maximumSafeDistance){
			needsInvestigation = true;
			lastPosition = currentPosition;
		}
	}

	public Vector3 GetStartingPosition() {
		return startingPosition;
	}

}
