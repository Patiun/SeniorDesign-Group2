using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DieAfterTime : MonoBehaviour {

	public int deathTime;
	private int count;

	void Start () {
		count = 0;
	}

	void UpdateFixed () {
		if (deathTime > count) {
			count++;
		} else {
			Destroy (this);
		}
	}
}
