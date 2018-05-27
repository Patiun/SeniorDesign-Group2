using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGameTrigger : MonoBehaviour {

	public GameState game;

	// Use this for initialization
	void Start () {
		game = GameObject.Find ("WorldController").GetComponent<GameState> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider col) {
		if (game == null) {
			game = GameObject.Find ("WorldController").GetComponent<GameState> ();
		}
		if (col.tag == "Player") {
			game.WinLevel ();
		}
	}
}
