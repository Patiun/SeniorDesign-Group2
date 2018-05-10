using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour {

	public int maxHP;
	public int curHP;
	public bool immortal = false;
	// Use this for initialization
	void Start () {
		curHP = maxHP;
	}
	
	public void DoDamage(int dmg) {
		if (!immortal) {
			curHP -= dmg;
			if (curHP <= 0) {
				GetComponent<GameState> ().LoseLevel ();
				curHP = 0;
			}
		}
	}

	public void Heal(int amnt) {
		curHP += amnt;
		if (curHP > maxHP) {
			curHP = maxHP;
		}
	}

	public void InstaKill() {
		if (!immortal) {
			curHP = 0;
			GetComponent<GameState> ().LoseLevel ();
		}
	}
}
