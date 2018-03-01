using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * Author: Greg Kilmer
 * Last Updated: 2/7/2018
 * */

public class TurretFire : MonoBehaviour {

	public Transform barrel_pos;
	public GameObject bullet_prefab;
	public float muzzle_velocity;


	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.F)) {
			Fire ();
		}
	}

	void Fire() {
		GameObject bullet = Instantiate (bullet_prefab,barrel_pos.transform.position,barrel_pos.transform.rotation);
		bullet.GetComponent<Rigidbody> ().velocity = barrel_pos.forward * muzzle_velocity;
	}
}
