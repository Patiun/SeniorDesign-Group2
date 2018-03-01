using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * Author: Greg Kilmer
 * Last Updated: 2/7/2018
 * */

public class DieOnCollision : MonoBehaviour {

	void OnCollisionEnter(Collision collision) {
		Destroy (this.gameObject);
	}
}
