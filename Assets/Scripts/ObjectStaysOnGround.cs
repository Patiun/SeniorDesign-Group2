using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectStaysOnGround : MonoBehaviour {

	public float startingY,startingZRotation;
	// Use this for initialization
	void Start () {
		startingY = transform.position.y;
		startingZRotation = transform.rotation.z;
	}
	
	// Update is called once per frame
	void Update () {
		if (transform.position.y != startingY) {
			transform.position = new Vector3 (transform.position.x, startingY, transform.position.z);
		}
		if (transform.rotation.z != startingZRotation) {
			transform.rotation = new Quaternion (transform.rotation.x, transform.rotation.y, startingZRotation,transform.rotation.w);
		}
	}
}
