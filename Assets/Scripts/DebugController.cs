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
	private GameObject player;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown ("`")||Input.GetKeyDown(KeyCode.Tab)) {
			isDebugging = !isDebugging;
			if (isDebugging) {
				Debug.Log ("[DEBUG] Debug Mode is Enabled");
			} else {
				Debug.Log ("[DEBUG] Debug Mode is Disabled");
			}
		}

		if (isDebugging) {
			if (Input.GetKeyDown (KeyCode.Space)) {
				Debug.Log ("[DEBUG] Force choosing objective");
				GetComponent<ObjectiveGeneration> ().ChooseObjective (Random.Range(0,int.MaxValue));
			}
			if (Input.GetKeyDown ("0")) {
				Debug.Log ("[DEBUG] Dificulty set to Easy");
				PlayerPrefs.SetInt("Difficulty",0);
			}
			if (Input.GetKeyDown ("1")) {
				Debug.Log ("[DEBUG] Dificulty set to Medium");
				PlayerPrefs.SetInt("Difficulty",1);
			}
			if (Input.GetKeyDown ("2")) {
				Debug.Log ("[DEBUG] Dificulty set to Hard");
				PlayerPrefs.SetInt("Difficulty",2);
			}
			if (Input.GetKeyDown("up")) {
				Debug.Log ("[DEBUG] World State Major Activity");
				worldState.MajorActivity();
			}
			if (Input.GetKeyDown("down")) {
				Debug.Log ("[DEBUG] World State Minor Activity");
				worldState.MinorActivity();
			}
			if (Input.GetKeyDown("r")) {
				Debug.Log ("[DEBUG] World State reset");
				worldState.Reset();
			}
			if (Input.GetKeyDown("z")) {
				Debug.Log ("[DEBUG] Level won");
				gameState.WinLevel ();
			}
			if (Input.GetKeyDown("x")) {
				Debug.Log ("[DEBUG] Level lost");
				gameState.LoseLevel ();
			}
			if (Input.GetKeyDown ("e")) {
				Debug.Log ("[DEBUG] Temporarily deactivating enemies");
				worldAI.DeactivateAllEnemies ();
			}
			if (Input.GetKeyDown ("p")) {
				if (player == null) {
					player = GameObject.FindGameObjectWithTag ("Player");
				}
				if (player.tag == "Player") {
					Debug.Log ("[DEBUG] Setting player tag to Untagged");
					player.tag = "Untagged";
				} else {
					Debug.Log ("[DEBUG] Returning player tag to Player");
					player.tag = "Player";
				}

			}
			if (Input.GetKeyDown ("d")) {
				Debug.Log ("[DEBUG] Toggling Doors");
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
			if (Input.GetKeyDown ("l")) {
				Debug.Log ("[DEBUG] Disabaling all lasers");
				GameObject[] traps = GameObject.FindGameObjectsWithTag ("Trap");
				foreach (GameObject trap in traps) {
					LazerGroupBehavior lazer = trap.GetComponent<LazerGroupBehavior> ();
					if (lazer != null) {
						lazer.groupOn = false;
					}
				}
			}
			if (Input.GetKeyDown ("f")) {
				Debug.Log ("[DEBUG] Disabaling all fans");
				GameObject[] traps = GameObject.FindGameObjectsWithTag ("Trap");
				foreach (GameObject trap in traps) {
					FanRotation fan = trap.GetComponent<FanRotation> ();
					if (fan != null) {
						fan.on = false;
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
					playerHealth.immortal = false;
					Debug.Log ("[DEBUG] Agent is no long Immortal");
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
