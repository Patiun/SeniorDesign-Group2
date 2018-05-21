using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEditor.UI;

public class ConnectionPuzzle : MonoBehaviour, IPointerDownHandler {

	public GameObject[] PathNodes;
	public GameObject[] PathPipes;
	public GameObject PuzzleWatcher;
	public float MoveSpeed;

	private float[] distances;
	private float Timer;
	private int currentNode;
	private Vector3 currentPositionHolder;
	private bool isActive;
	private bool success;
    

	private Vector3 OriginalBoxPosition;
    
	// Use this for initialization
	void Start () {
		success = false;

		distances = new float[PathPipes.Length];
		for (int i = 0; i < distances.Length; i++)
		{
			distances[i] = Vector3.Distance(gameObject.transform.position, PathNodes[i].transform.position);
		}

		gameObject.GetComponent<UnityEngine.UI.Image>().color = Color.blue;
		Timer = 0;
		OriginalBoxPosition = gameObject.transform.position;
		currentNode = 0;
		currentPositionHolder = PathNodes[currentNode].transform.position;
		isActive = false;

		for (int i = 0; i < PathNodes.Length; i++){
			//PathLegs[i].gameObject.GetComponent<UnityEngine.UI.Image>().color = Color.red;
			PathPipes[i].gameObject.GetComponent<UnityEngine.UI.Image>().fillAmount = 100;
		}
	}
	
	// Update is called once per frame
	void Update () {
		
		if (isActive == true)
		{
			Timer += Time.deltaTime * MoveSpeed;

			if (gameObject.transform.position != currentPositionHolder)
			{
				gameObject.transform.position = Vector3.Lerp(gameObject.transform.position, currentPositionHolder, Timer);
				PathPipes[currentNode].gameObject.GetComponent<UnityEngine.UI.Image>().fillAmount = Vector3.Distance(gameObject.transform.position, currentPositionHolder)/distances[currentNode];
			}
			else
			{
				//PathLegs[currentNode].gameObject.GetComponent<UnityEngine.UI.Image>().color = Color.green;

				if (currentNode < (PathNodes.Length - 1))
				{
					currentNode++;
				}
				Timer = 0;
				currentPositionHolder = PathNodes[currentNode].transform.position;
			}
		}

		if(currentNode == PathNodes.Length-1 && isActive == true){
			success = true;
		}

	}

	public void OnPointerDown(PointerEventData eventData){
		if (PuzzleWatcher.gameObject.GetComponent<PuzzleBheavior>().getHasCollided() == false)
		{
			PuzzleWatcher.gameObject.GetComponent<PuzzleBheavior>().incrementTurn();
			isActive = true;
		}
	}

	public void OnTriggerEnter2D(Collider2D collision){
		isActive = false;
		gameObject.GetComponent<UnityEngine.UI.Image>().color = Color.red;
		PuzzleWatcher.gameObject.GetComponent<PuzzleBheavior>().setHasCollided(true);

    }

	public void Reset(){
		Timer = 0;
		PuzzleWatcher.gameObject.GetComponent<PuzzleBheavior>().setHasCollided(false);
		gameObject.GetComponent<UnityEngine.UI.Image>().color = Color.blue;
		gameObject.transform.position = OriginalBoxPosition;
        currentNode = 0;
        currentPositionHolder = PathNodes[currentNode].transform.position;
        isActive = false;

		for (int i = 0; i < PathNodes.Length; i++)
        {
			//PathLegs[i].gameObject.GetComponent<UnityEngine.UI.Image>().color = Color.red;
            PathPipes[i].gameObject.GetComponent<UnityEngine.UI.Image>().fillAmount = 100;        
		}
	}

	public bool isSuccessful(){
		return success;
	}


}
