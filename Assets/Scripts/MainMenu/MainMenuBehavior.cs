using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuBehavior : MonoBehaviour {

	public Canvas mainSelection;
	public Canvas levelSelection;
	public GameObject cameraObject;
	public Camera camera;
	public Button btnLevelSelect;
	public GameObject leftDoor;
	public GameObject rightDoor;
	public float cameraDestination;
	public float cameraRotation;

	public GameObject NewGameObject;
	public GameObject LevelSelectObject;
	public GameObject HowToPlayObject;

	public GameObject elevatorLight;

	public Material downMaterial;

	private bool moveToLevelSelect;
	private bool rotateToLevelSelect;
	private bool closingDoors;

	private Vector3 destination;
	private Vector3 leftDoorStarting;
	private Vector3 rightDoorStarting;
	private Vector3 leftDoorDestination;
	private Vector3 rightDoorDestination;
	private bool newGame;

	private int sceneIndex = 0;

	//private Quaternion originalRotation;
	private Quaternion toRotation;


	// Use this for initialization
	void Start () {
		newGame = false;
		cameraObject.SetActive (true);
		mainSelection.enabled = false;
		levelSelection.enabled = false;
		closingDoors = false;
		moveToLevelSelect = false;
		rotateToLevelSelect = false;
		destination = new Vector3(camera.gameObject.transform.position.x, camera.gameObject.transform.position.y, cameraDestination);
		leftDoorStarting = leftDoor.transform.position;
		rightDoorStarting = rightDoor.transform.position;
		leftDoorDestination = new Vector3(-2.0f, leftDoor.transform.position.y, leftDoor.transform.position.z);
		rightDoorDestination = new Vector3(2.0f, leftDoor.transform.position.y, leftDoor.transform.position.z);

		elevatorLight.SetActive(false);

		Vector3 byAngle = new Vector3(0, cameraRotation, 0);
		toRotation = Quaternion.Euler(transform.eulerAngles + byAngle);

	}
	
	// Update is called once per frame
	void Update () {
		if(moveToLevelSelect == true){
			camera.transform.position = Vector3.Lerp(camera.transform.position, destination, Time.deltaTime * 1.5f);
			leftDoor.transform.position = Vector3.Lerp(leftDoor.transform.position, leftDoorDestination, Time.deltaTime * 2);
			rightDoor.transform.position = Vector3.Lerp(rightDoor.transform.position, rightDoorDestination, Time.deltaTime * 2);
			elevatorLight.SetActive(true);
			if (Mathf.Abs(camera.transform.position.z - cameraDestination) <= .1)
            {
				if (newGame == true)
				{
					SceneManager.LoadScene(sceneIndex);
				}
				else
				{
					moveToLevelSelect = false;
					rotateToLevelSelect = true;
				}
            }
		}
		else if(rotateToLevelSelect == true){
			camera.transform.rotation = Quaternion.Lerp(camera.transform.rotation, toRotation, Time.deltaTime * 5);
		}

		if(closingDoors == true){
			leftDoor.transform.position = Vector3.Lerp(leftDoor.transform.position, leftDoorStarting, Time.deltaTime * 2);
            rightDoor.transform.position = Vector3.Lerp(rightDoor.transform.position, rightDoorStarting, Time.deltaTime * 2);

			if(Mathf.Abs(leftDoor.transform.position.x - leftDoorStarting.x) <= .0025){
				LoadScene();
			}
		}
	}

	public void closeDoors(int _sceneIndex){
		closingDoors = true;
		sceneIndex = _sceneIndex;
	}

	public void NewGameClicked(){
		PlayerPrefs.SetInt("Difficulty", 0);
		sceneIndex = Random.Range(0,4);
		newGame = true;
		moveToLevelSelect = true;
		//SceneManager.LoadScene(1);
	}

	public void LevelOneClicked(){
		sceneIndex = 1;
		//SceneManager.LoadScene(1);
	}
	public void LevelTwoClicked()
    {
		sceneIndex = 2;
        //SceneManager.LoadScene(2);
    }
	public void LevelThreeClicked()
    {
		sceneIndex = 3;
        //SceneManager.LoadScene(3);
    }

	public void LevelFourClicked(){
		sceneIndex = 4;
	}
   
	public void LevelSelectClicked(){
		moveToLevelSelect = true;
		mainSelection.enabled = false;
	}

	public void LoadScene(){
		SceneManager.LoadScene(sceneIndex);
	}

}
