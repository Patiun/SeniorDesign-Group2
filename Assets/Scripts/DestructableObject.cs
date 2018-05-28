using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructableObject : MonoBehaviour {

	public int ObjectHealth;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void takeDamage(int dmg){
		ObjectHealth = ObjectHealth - dmg;
		if(ObjectHealth <= 0){
			if (gameObject.tag == "Keycard")
				LevelGeneration.SharedInstance.RespawnKeycard ();
			Destroy(gameObject);
		}
	}
}
