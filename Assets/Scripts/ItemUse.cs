using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * Author: Greg Kilmer
 * Last Updated: 2/28/2018
 * */

public abstract class ItemUse : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	//Gets Overriden by any class extending this one to use an object
	public abstract void Use ();

	public abstract Transform GetAnchorPoint ();

	public abstract Vector3 GetAnchorEulerAngles ();
}
