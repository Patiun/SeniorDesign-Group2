using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdatePlayerTags : MonoBehaviour {

	public Collider[] coliders;
	public LayerMask playerLayer;

	// Use this for initialization
	void Start () {
		coliders = GetComponentsInChildren<Collider> ();
		for (int i = 0; i < coliders.Length; i++) {
			coliders [i].gameObject.tag = "Player";
			coliders [i].gameObject.layer = 9;
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
