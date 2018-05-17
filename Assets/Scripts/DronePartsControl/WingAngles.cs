using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WingAngles : MonoBehaviour {
	public NavMeshAgent nma;
	public Transform WingPrimaryAxis;
	public Transform[] WingSecondaryAxes;
	public float WingPrimaryAxisScaling = 6f;
	public float WingPrimaryAxisLerpScale =.7f;
	public float wobbleFrequency = 1f;
	public float wobbleStrength = 5f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 velocity = nma.velocity;
		float newRotation = -160f + 160f * nma.velocity.magnitude / WingPrimaryAxisScaling;
		float noise = Mathf.PerlinNoise (Time.time * (wobbleFrequency), 0f) * wobbleStrength;
		newRotation += noise;
		WingPrimaryAxis.localRotation = Quaternion.Lerp(WingPrimaryAxis.localRotation, 
											Quaternion.Euler(newRotation, 0f, 0f),
											WingPrimaryAxisLerpScale
										);
		
	}
}
