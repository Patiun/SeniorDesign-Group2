using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * Author: Greg Kilmer
 * Last Updated: 2/28/2018
 * */

public class GunUse : ItemUse {

	public Transform barrel_pos;
	public Transform grip_pos;
	public GameObject bullet_prefab;
	public float muzzle_velocity;
	public float grip_angle;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public override void Use() {
		Debug.Log ("GunUse");
		GameObject bullet = Instantiate (bullet_prefab,barrel_pos.transform.position,barrel_pos.transform.rotation);
		bullet.GetComponent<Rigidbody> ().velocity = barrel_pos.forward * muzzle_velocity;
	}

	public override Transform GetAnchorPoint () { 
		return grip_pos;
	}

	public override Vector3 GetAnchorEulerAngles () {
		return new Vector3 (0, 0, 0);
	}

	public void OnCollisionEnter(Collision c) {
		if (c.gameObject.tag.Equals("PlayerHand")) {
			Debug.Log("highlight this");
		}
	}
}
