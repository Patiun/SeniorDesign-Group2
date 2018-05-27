using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour {

	public float shootCooldown; //In seconds
	public GameObject[] barrels;
	public int barrelIndex = 0;
	public float warmUpTime = 1.0f; //Warm up in seconds
	public bool warmedUp;
	public float timeLastFired;
	public float forcedCoolDownTime;
	public float count;

	public GameObject bulletPrefab;
	public float bulletVelocity;
	public AudioSource shotSound,laserReady,laserWarmup,LaserCooldown;

	// Use this for initialization
	void Start () {
		warmedUp = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (warmedUp && Time.time - timeLastFired >= forcedCoolDownTime) {
			Discard ();
		} else {
			timeLastFired = Time.time;
		}
	}

	public void HasTarget(Vector3 targetLocation) {
		if (warmedUp) {
			if (!laserReady.isPlaying) {
				laserReady.Play ();
			}
			for (int i = 0; i < barrels.Length; i++) {
				barrels [i].transform.LookAt (targetLocation);
			}
			if (count >= shootCooldown) {
				FireBullet (barrels [barrelIndex].transform);
				count = 0;
				barrelIndex++;
				if (barrelIndex >= barrels.Length) {
					barrelIndex = 0;
				}
			} else {
				count += Time.deltaTime;
			}
		} else {
			count += Time.deltaTime;
			if (warmUpTime - count < 0.02 && !laserWarmup.isPlaying) {
				laserWarmup.Play ();
			}
			if (count >= warmUpTime) {
				warmedUp = true;
				count = 0;
			}
		}
	}

	/*
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
	}*/

	private void FireBullet(Transform muzzle) {
		shotSound.Play ();
		//GameObject bullet = Instantiate (bulletPrefab);
		GameObject bullet = ObjectPooler.SharedInstance.GetPooledObject();
		if (bullet != null) {
			bullet.transform.position = muzzle.position;
			bullet.transform.rotation = muzzle.rotation;
			bullet.GetComponent<Rigidbody> ().AddForce (muzzle.forward * bulletVelocity);
			timeLastFired = Time.time;
		} else {
			Debug.LogError ("[ERROR] Not Enough Bullets");
		}
	}

	public void Discard() {
		count = 0;
		warmedUp = false;
		LaserCooldown.Play ();
		laserReady.Stop ();
	}
}
