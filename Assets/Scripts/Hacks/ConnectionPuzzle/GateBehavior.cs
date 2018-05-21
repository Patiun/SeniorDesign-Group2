using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateBehavior : MonoBehaviour {

	//public Sprite[] openClose;

	public Sprite openSprite;
	public Sprite closedSprite;

	public bool isOpen;
	public GameObject PuzzleWatcher;

	private int currentTurn;

	// Use this for initialization
	void Start () {
		currentTurn = PuzzleWatcher.GetComponent<PuzzleBheavior>().getTurn();
		if (isOpen == true){
			gameObject.GetComponent<UnityEngine.UI.Image>().sprite = openSprite;
			gameObject.GetComponent<BoxCollider2D>().enabled = false;
		}
		else{
			gameObject.GetComponent<UnityEngine.UI.Image>().sprite = closedSprite;
			gameObject.GetComponent<BoxCollider2D>().enabled = true;
		}
	}
	
	// Update is called once per frame
	void Update () {
		if(currentTurn != PuzzleWatcher.GetComponent<PuzzleBheavior>().getTurn()){
			currentTurn = PuzzleWatcher.GetComponent<PuzzleBheavior>().getTurn();
			flipPicture();
		}
	}

	void flipPicture(){
		//if (currentTurn % 2 == 0)
		//{
		//	gameObject.GetComponent<UnityEngine.UI.Image>().sprite = openClose[1];
		//}
		//else{
		//	gameObject.GetComponent<UnityEngine.UI.Image>().sprite = openClose[0];
		//}
		if(isOpen == true){
			gameObject.GetComponent<UnityEngine.UI.Image>().sprite = closedSprite;
			gameObject.GetComponent<BoxCollider2D>().enabled = true;
			isOpen = false;
		}
		else{
			gameObject.GetComponent<UnityEngine.UI.Image>().sprite = openSprite;
			gameObject.GetComponent<BoxCollider2D>().enabled = false;
			isOpen = true;
		}
	}
}
