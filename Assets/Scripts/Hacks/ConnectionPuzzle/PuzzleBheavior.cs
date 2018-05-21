using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.UI;

public class PuzzleBheavior : MonoBehaviour {

	public GameObject[] puzzles;
	public float timer;
	public GameObject timeLeftText;

	private GameObject activePuzzle;
	private float timeLeft;
	private bool hasCollided;
	private int turn;

	// Use this for initialization
	void Start () {
		turn = 0;
		hasCollided = false;
		timeLeft = timer;
		timeLeftText.GetComponent<UnityEngine.UI.Text>().text = "Time Left: " + timeLeft;
		activePuzzle = puzzles[Random.Range(0, puzzles.Length)];
		activePuzzle.SetActive(true);
	}
	
	// Update is called once per frame
	void Update () {
		timeLeft -= Time.deltaTime;
		timeLeftText.GetComponent<UnityEngine.UI.Text>().text = "Time Left: " + timeLeft;
	}
    
	public void Restart()
	{
		ConnectionPuzzle[] connectionPuzzles = activePuzzle.GetComponentsInChildren<ConnectionPuzzle>();
		for (int i = 0; i < connectionPuzzles.Length; i++){
			connectionPuzzles[i].Reset();
		}

	}

	public void setHasCollided(bool col){
		hasCollided = col;
	}

	public bool getHasCollided(){
		return hasCollided;
	}

	public int getTurn(){
		return turn;
	}
}
