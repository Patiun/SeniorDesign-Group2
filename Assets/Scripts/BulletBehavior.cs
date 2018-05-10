using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehavior : MonoBehaviour {

	public int damageValue;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter(Collision col) {
		if (col.collider.isTrigger && col.gameObject.tag == "Player") {
			GameObject.FindGameObjectWithTag ("GameController").GetComponent<PlayerHealth> ().DoDamage (damageValue);
			Destroy (this.gameObject);
		}
	}
}
