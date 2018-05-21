using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.UI;

public class PuzzleBheavior : MonoBehaviour
{

	public GameObject[] puzzles;
	public float timer;
	public GameObject timeLeftText;

	private GameObject activePuzzle;
	private GameObject boxes;
	private float timeLeft;
	private bool hasCollided;
	private int turn;
	private ConnectionPuzzle[] connectionPuzzles;

	// Use this for initialization
	void Start () {
		turn = 0;
		hasCollided = false;
		timeLeft = timer;
		timeLeftText.GetComponent<UnityEngine.UI.Text>().text = "Time Left: " + timeLeft;
		activePuzzle = puzzles[Random.Range(0, puzzles.Length)];
		activePuzzle.SetActive(true);
		connectionPuzzles = activePuzzle.GetComponentsInChildren<ConnectionPuzzle>();
		Debug.Log(connectionPuzzles.Length);
	}
	
	// Update is called once per frame
	void Update () {
		timeLeft -= Time.deltaTime;
		timeLeftText.GetComponent<UnityEngine.UI.Text>().text = "Time Left: " + timeLeft;
		if(timeLeft <= 0){
			lose();
		}
		else{
			int winner = 1;
			for (int i = 0; i < connectionPuzzles.Length; i++){
				if(connectionPuzzles[i].isSuccessful() == true){
					winner = winner * 1;
				}
				else{
					winner = winner * 0;
				}
			}
			if(winner == 1){
				win();
			}
		}
	}
    
	public void Restart()
	{
		turn = 0;
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

	public void incrementTurn(){
		turn++;
	}

	private void lose(){
		Debug.Log("LOSE");
	}

	private void win(){
		Debug.Log("WIN");
	}
}
