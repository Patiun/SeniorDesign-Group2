using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : MonoBehaviour {

	private float startTime;
	private float endTime;
	public AudioSource gameOverSound;
	public Canvas winningCanvas;
	public Canvas losingCanvas;
	public Canvas operatorCanvas;

	// Use this for initialization
	void Start () {
		startTime = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void WinLevel() {
		endTime = Time.time;
		Debug.Log ("Level Successful!");
		operatorCanvas.enabled = false;
		winningCanvas.enabled = true;
	}

	public void LoseLevel() {
		endTime = Time.time;
		Debug.Log ("You lose!");
		gameOverSound.Play ();
		operatorCanvas.enabled = false;
		losingCanvas.enabled = true;
	}
}
