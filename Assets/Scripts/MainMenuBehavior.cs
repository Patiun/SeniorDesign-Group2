using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuBehavior : MonoBehaviour {

	public Canvas mainSelection;
	public Canvas levelSelection;
	public Camera camera;
	public Button btnLevelSelect;
	public GameObject leftDoor;
	public GameObject rightDoor;
	public float cameraDestination;

	private bool moveToLevelSelect;
	private Vector3 destination;
	private Vector3 leftDoorDestination;
	private Vector3 rightDoorDestination;


	// Use this for initialization
	void Start () {
		mainSelection.enabled = true;
		levelSelection.enabled = false;
		moveToLevelSelect = false;
		destination = new Vector3(camera.gameObject.transform.position.x, camera.gameObject.transform.position.y, cameraDestination);
		leftDoorDestination = new Vector3(-2.0f, leftDoor.transform.position.y, leftDoor.transform.position.z);
		rightDoorDestination = new Vector3(2.0f, leftDoor.transform.position.y, leftDoor.transform.position.z);
	}
	
	// Update is called once per frame
	void Update () {
		if(moveToLevelSelect == true){
			camera.transform.position = Vector3.Lerp(camera.transform.position, destination, Time.deltaTime * 2);
			leftDoor.transform.position = Vector3.Lerp(leftDoor.transform.position, leftDoorDestination, Time.deltaTime * 2);
			rightDoor.transform.position = Vector3.Lerp(rightDoor.transform.position, rightDoorDestination, Time.deltaTime * 2);
		}
		if(Mathf.Abs(camera.transform.position.z - cameraDestination) <= .1){
			levelSelection.enabled = true;
		}
		
	}

	public void NewGameClicked(){
		SceneManager.LoadScene(1);
	}

	public void LevelOneClicked(){
		SceneManager.LoadScene(1);
	}
	public void LevelTwoClicked()
    {
        SceneManager.LoadScene(2);
    }
	public void LevelThreeClicked()
    {
        SceneManager.LoadScene(3);
    }
   
	public void LevelSelectClicked(){
		moveToLevelSelect = true;
		mainSelection.enabled = false;
	}


}
