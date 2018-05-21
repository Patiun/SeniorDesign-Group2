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
	public GameObject scripts;
	public Transform deathLocation;
	public Transform winLocation;
	public GameObject player;

	// Use this for initialization
	void Start () {
		startTime = Time.time;
		//Time.timeScale = 1.0f;
		scripts.SetActive (true);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void WinLevel() {
		endTime = Time.time;
		Debug.Log ("Level Successful!");
		operatorCanvas.enabled = false;
		GetComponent<WorldAIHandler> ().DeactivateAllEnemies ();
		player.transform.position = winLocation.position;
		player.transform.rotation = winLocation.rotation;
		//winningCanvas.enabled = true;
		winningCanvas.gameObject.SetActive (true);
		//Time.timeScale = 0.0f;
		scripts.SetActive (false);
	}

	public void LoseLevel() {
		endTime = Time.time;
		Debug.Log ("You lose!");
		gameOverSound.Play ();
		player.transform.position = deathLocation.position;
		player.transform.rotation = deathLocation.rotation;
		operatorCanvas.enabled = false;
		losingCanvas.gameObject.SetActive (true);
		//Time.timeScale = 0.0f;
		scripts.SetActive (false);
	}
}
