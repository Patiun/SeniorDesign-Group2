using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundFunctionality : MonoBehaviour {

	public float timeLimit = .5f;
	private float count = 0;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (count >= timeLimit) {
			Destroy (this.gameObject);
		} else {
			count += Time.deltaTime;
		}
	}

	public void OnTriggerEnter(Collider col) {
		if (col.tag == "Enemy" && col.isTrigger == false) {
			col.gameObject.GetComponent<EnemyAI> ().MinorActivity (transform.position);
		}
	}
}
