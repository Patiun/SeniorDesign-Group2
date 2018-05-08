using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour {

	public int maxHP;
	public int curHP;
	// Use this for initialization
	void Start () {
		curHP = maxHP;
	}
	
	public void DoDamage(int dmg) {
		curHP -= dmg;
		if (curHP) {
			GetComponent<GameState> ().LoseLevel ();
			curHP = 0;
		}
	}

	public void Heal(int amnt) {
		curHP += amnt;
		if (curHP > maxHP) {
			curHP = maxHP;
		}
	}
}
