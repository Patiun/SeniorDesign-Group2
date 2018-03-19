using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DieAfterTime : MonoBehaviour {

	public int deathTime;
	public int count;

	void Start () {
		count = 0;
	}

	void Update () {
		if (deathTime > count) {
			count++;
		} else {
			Destroy (this);
		}
	}
}
