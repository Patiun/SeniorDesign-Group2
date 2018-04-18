﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyVisionDetection : MonoBehaviour {

	public EnemySight es;

	void OnTriggerEnter(Collider col) {
		if (col.tag == "Player") {
			es.PlayerSweep (col.gameObject);
		}
	}

	void OnTriggerStay(Collider col) {
		if (col.tag == "Player") {
			es.PlayerSweep (col.gameObject);
		}
	}
}