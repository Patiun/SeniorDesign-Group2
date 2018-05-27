using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DebugController : MonoBehaviour {

	public bool isDebugging = false;
	public WorldState worldState;
	public GameState gameState;
	public PlayerHealth playerHealth;
	public WorldAIHandler worldAI;

	private WorldState.State lastState;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown ("`")) {
			isDebugging = !isDebugging;
			if (isDebugging) {
				Debug.Log ("[DEBUG] Debug Mode is Enabled");
			} else {
				Debug.Log ("[DEBUG] Debug Mode is Disabled");
			}
		}

		if (isDebugging) {
			if (Input.GetKeyDown (KeyCode.Space)) {
				GetComponent<ObjectiveGeneration> ().ChooseObjective (Random.Range(0,int.MaxValue));
			}
			if (Input.GetKeyDown ("0")) {
				PlayerPrefs.SetInt("Difficulty",0);
			}
			if (Input.GetKeyDown ("1")) {
				PlayerPrefs.SetInt("Difficulty",1);
			}
			if (Input.GetKeyDown ("2")) {
				PlayerPrefs.SetInt("Difficulty",2);
			}
			if (Input.GetKeyDown("up")) {
				worldState.MajorActivity();
			}
			if (Input.GetKeyDown("down")) {
				worldState.MinorActivity();
			}
			if (Input.GetKeyDown("r")) {
				worldState.Reset();
			}
			if (Input.GetKeyDown("z")) {
				gameState.WinLevel ();
			}
			if (Input.GetKeyDown("x")) {
				gameState.LoseLevel ();
			}
			if (Input.GetKeyDown ("e")) {
				worldAI.DeactivateAllEnemies ();
			}
			if (Input.GetKeyDown ("d")) {
				GameObject[] doors = GameObject.FindGameObjectsWithTag ("Door");
				foreach (GameObject door in doors) {
					Door doorS = door.GetComponent<Door> ();
					if (doorS.isClosed || doorS.isClosing) {
						doorS.Open ();
					} else {
						doorS.Close ();
					}
				}
			}
			if (Input.GetKeyDown (KeyCode.Backspace)) {
				SceneManager.LoadScene (SceneManager.GetActiveScene ().name);
			}
			if (Input.GetKeyDown ("i")) {
				if (!playerHealth.immortal) {
					playerHealth.immortal = true;
					Debug.Log ("[DEBUG] Agent is now Immortal");
				} else {
					playerHealth.immortal = true;
					Debug.Log ("[DEBUG] Agent is now Immortal");
				}
			}
			WorldState.State curState = worldState.GetState ();
			if (curState != lastState) {
				Debug.Log ("[DEBUG]"+ curState);
				lastState = curState;
			}
		}
	}
}
