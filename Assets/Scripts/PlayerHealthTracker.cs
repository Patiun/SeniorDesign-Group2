using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthTracker : MonoBehaviour {

	public Image health;
	public PlayerHealth playerHealth;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		health.fillAmount = ((float)(playerHealth.curHP) / (float)(playerHealth.maxHP));
	}
}
