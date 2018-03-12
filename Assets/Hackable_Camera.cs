using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Hackable))]
public class Hackable_Camera : MonoBehaviour {
	public GameObject ObjectMapping_object;
	public GameObject FaceSquare;

	public void OnHack() {
		ObjectMapping_object.SetActive(true);
		FaceSquare.GetComponent<MeshRenderer> ().material.color = (Color.green);
	}
}
