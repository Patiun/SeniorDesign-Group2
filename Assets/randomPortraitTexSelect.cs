using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class randomPortraitTexSelect : MonoBehaviour {
	public Texture2D[] faces;
	// Use this for initialization
	void Start () {
		GetComponent<MeshRenderer> ().material.mainTexture = faces [Random.Range (0, faces.Length - 1)];
	}
}
