using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    private bool isLose;
	// Use this for initialization
	void Start () {
		//turn = 0;
		//hasCollided = false;
		//timeLeft = timer;
		//timeLeftText.GetComponent<UnityEngine.UI.Text>().text = "Time Left: " + timeLeft;
		//activePuzzle = puzzles[Random.Range(0, puzzles.Length)];
		//activePuzzle.SetActive(true);
		//connectionPuzzles = activePuzzle.GetComponentsInChildren<ConnectionPuzzle>();
		//Debug.Log(connectionPuzzles.Length);
	}

	private void OnEnable()
	{
		turn = 0;
        hasCollided = false;
        timeLeft = timer + Time.deltaTime;
        //timeLeftText.GetComponent<UnityEngine.UI.Text>().text = "Time Left: " + timeLeft;
        activePuzzle = puzzles[Random.Range(0, puzzles.Length)];
        activePuzzle.SetActive(true);
        connectionPuzzles = activePuzzle.GetComponentsInChildren<ConnectionPuzzle>();
        isLose = false;
        CanvasManager.Instance.DisableRayCastingBlocker();
        //Debug.Log(connectionPuzzles.Length);
	}

	private void OnDisable()
	{
		activePuzzle.SetActive(false);
        
    }

	// Update is called once per frame
	void Update () {
		timeLeft -= Time.deltaTime;
        if(!isLose)
		    timeLeftText.GetComponent<UnityEngine.UI.Text>().text = "Time Left: " + timeLeft;
		if(timeLeft <= 0){
			lose();
            isLose = true;
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
        timeLeft = timer + Time.deltaTime;
        isLose = false;


    }

    public void Reset()
    {
        Restart();
        CanvasManager.Instance.EnableRayCastingBlocker();
        gameObject.transform.parent.gameObject.SetActive(false);
        CameraManager.Instance.SwitchMainCamera();
        gameObject.SetActive(false);
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
        timeLeftText.GetComponent<UnityEngine.UI.Text>().text = "Time Left: " + 0;
        HackManager.Instance.InProgress = false;
        Reset();
	}

	private void win(){
        Reset();
        HackManager.Instance.FinishHacking(true);
	}
}
