using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HackableIconToHackableObject : MonoBehaviour {

	public GameObject target;
	public Camera camera;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = camera.WorldToScreenPoint (target.transform.position);
	}
}
