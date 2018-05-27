using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DieAfterTime : MonoBehaviour {

	public int deathTime;
	public int count;

	void OnEnable () {
		count = 0;
	}

	void Update () {
		if (deathTime > count) {
			count++;
		} else {
			count = 0;
			gameObject.SetActive (false);
		}
	}
}
