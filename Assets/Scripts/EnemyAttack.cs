using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour {

	public float shootCooldown; //In seconds
	public GameObject charge;
	public float chargeTime = 0.5f; //Percent of time
	public int count;

	public GameObject bulletPrefab;
	public float bulletVelocity;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public bool Shoot() {
		if (count >= shootCooldown * 1000) {
			Transform muzzlePos = charge.transform;
			charge.SetActive (false);
			FireBullet (muzzlePos);
			count = 0;
			return true;
		} else {
			count++;
			if (count >= shootCooldown * 1000 * chargeTime) {
				charge.SetActive (true);
			}
			return false;
		}
	}

	private void FireBullet(Transform muzzle) {
		GameObject bullet = Instantiate (bulletPrefab);
		bullet.transform.position = muzzle.position;
		bullet.GetComponent<Rigidbody> ().AddForce (muzzle.forward * bulletVelocity);
	}

	public void Discard() {
		count = 0;
		charge.SetActive (false);
	}
}
