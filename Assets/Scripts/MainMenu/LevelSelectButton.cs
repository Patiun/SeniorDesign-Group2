using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSelectButton : MonoBehaviour {

	public MainMenuBehavior mainMenuBehavior;
	public AudioSource uiSound;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnMouseDown(){
		uiSound.Play ();
		mainMenuBehavior.LevelSelectClicked();
	}
}
