﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdatePlayerTags : MonoBehaviour {

	// Use this for initialization
	void Start () {
		GameState gameState = GameObject.Find ("WorldController").GetComponent<GameState> ();
		gameState.player = this.transform.gameObject;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
