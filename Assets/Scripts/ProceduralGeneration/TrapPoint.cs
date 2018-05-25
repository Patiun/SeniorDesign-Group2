using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapPoint : MonoBehaviour {

	public List<GameObject> potentialTraps;
	public GameObject fanTrap;
	public bool fanEnabled;

	// Use this for initialization
	void Start () {
		
	}
	
	public void Generate() {
		//Random.InitState (GameObject.Find ("LevelGenerator").GetComponent<LevelGeneration> ().seed);
		if (fanEnabled && !potentialTraps.Contains(fanTrap)) {
			potentialTraps.Add (fanTrap);
		}
		int trapInd = Random.Range (0, potentialTraps.Count);
		GameObject newTrap = Instantiate(potentialTraps [trapInd]);
		newTrap.transform.parent = transform;
		if (newTrap.GetComponent<LazerGroupBehavior> () != null) {
			newTrap.transform.position = new Vector3(transform.position.x,transform.position.y+1f,transform.position.z);
		} else {
			newTrap.transform.position = transform.position;
			FanRotation fan = newTrap.GetComponent<FanRotation> ();
			if (fan != null) {
				fan.playerHealth = GameObject.Find ("WorldController").GetComponent<PlayerHealth> ();
			}
		}
		newTrap.transform.rotation = transform.rotation;
	}

	void OnDrawGizmos(){
		Gizmos.DrawWireCube (new Vector3(transform.position.x,transform.position.y+1f,transform.position.z),  Quaternion.AngleAxis(transform.rotation.eulerAngles.y,transform.up) * (new Vector3 (5f, 2f, 1f)));
		Gizmos.DrawWireCube (new Vector3(transform.position.x,transform.position.y,transform.position.z), Quaternion.AngleAxis(transform.rotation.eulerAngles.y,transform.up) * (new Vector3 (3.4f, 3f, 1f)));
		Gizmos.DrawWireSphere (transform.position, 0.1f);
	}
}
