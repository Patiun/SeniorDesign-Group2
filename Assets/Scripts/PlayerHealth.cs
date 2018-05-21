using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour {

	public int maxHP;
	public int curHP;
	public bool immortal = false;

	public Color fogColorCalm, fogColorAlert, fogColorHurt;
	public bool alert = false;
	// Use this for initialization
	void Start () {
		curHP = maxHP;
		UpdateFog ();
	}
	
	public void DoDamage(int dmg) {
		if (!immortal) {
			curHP -= dmg;
			if (curHP <= 0) {
				GetComponent<GameState> ().LoseLevel ();
				curHP = 0;
			}
		}
		UpdateFog ();
	}

	public void Heal(int amnt) {
		curHP += amnt;
		if (curHP > maxHP) {
			curHP = maxHP;
		}
		UpdateFog ();
	}

	public void InstaKill() {
		if (!immortal) {
			curHP = 0;
			GetComponent<GameState> ().LoseLevel ();
		}
		UpdateFog ();
	}

	public void UpdateFog() {
		alert = GetComponent<WorldState> ().isAlert;
		Color useColor = alert ? fogColorAlert : fogColorCalm;
		RenderSettings.fogColor = Color.Lerp (fogColorHurt, useColor, ((float)curHP)/((float)maxHP));
	}

	void Update() {
		UpdateFog ();
	}
}
