using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DebugController : MonoBehaviour {

	public bool isDebugging = false;
	public WorldState worldState;
	public PlayerHealth playerHealth;

	public GameObject targetEnemy;
	public float rotationSpeed = 1f, angleIterationSpeed = 25f;

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
			if (Input.GetKeyDown("up")) {
				worldState.MajorActivity();
			}
			if (Input.GetKeyDown("down")) {
				worldState.MinorActivity();
			}
			if (Input.GetKeyDown("r")) {
				worldState.Reset();
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

			if (targetEnemy != null) {
				if (Input.GetKey (KeyCode.T)) {
					Debug.Log ("[DEBUG] Rotating target enemy "+targetEnemy.transform.eulerAngles);
					Vector3 angles = targetEnemy.transform.eulerAngles;
					angles.y += angleIterationSpeed*Time.deltaTime;
					Quaternion newRotation = Quaternion.Euler (angles);
					targetEnemy.transform.rotation = Quaternion.Slerp (targetEnemy.transform.rotation, newRotation, rotationSpeed);
				}
				if (Input.GetKeyDown (KeyCode.Y)) {
					Debug.Log ("[DEBUG] Flipped target enemy rotation direction");
					angleIterationSpeed *= -1;
				}
			}
		}
	}
}
