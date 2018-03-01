using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyColliderController : MonoBehaviour {

	private Quaternion reset;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		Transform cam = GetComponentInParent<Transform> ();
		transform.rotation = Quaternion.Inverse (cam.transform.rotation);
		//??????//
	}
}
