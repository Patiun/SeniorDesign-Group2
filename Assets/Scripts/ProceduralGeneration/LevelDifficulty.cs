using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelDifficulty : MonoBehaviour {

	public enum Difficulty {EASY,MEDIUM,HARD};
	public Difficulty difficulty;
	public int numEnemies,numTraps,minPatrolSize,maxPatrolSize,numCameras;
	public float enemyHelpRadius;

	public void SetDifficulty(Difficulty dif) {
		difficulty = dif;
	}

	public void SetDifficulty(int dif) {
		switch (dif) {
		case 0:
			difficulty = Difficulty.EASY;
			break;
		case 1:
			difficulty = Difficulty.MEDIUM;
			break;
		case 2:
			difficulty = Difficulty.HARD;
			break;
		default:
			difficulty = Difficulty.EASY;
			break;
		}
	}

	public void PopulateValues() {

		//Pull Difficulty from player settings
		int dif = PlayerPrefs.GetInt ("Difficulty");
		SetDifficulty (dif);

		switch (difficulty) {
		case Difficulty.EASY:
			numEnemies = 2;
			numTraps = 2;
			numCameras = 2;
			minPatrolSize = 5;
			maxPatrolSize = 5;
			enemyHelpRadius = 35f;
			break;
		case Difficulty.MEDIUM:
			numEnemies = 3;
			numTraps = 3;
			numCameras = 3;
			minPatrolSize = 5;
			maxPatrolSize = 6;
			enemyHelpRadius = 35f;
			break;
		case Difficulty.HARD:
			numEnemies = 6;
			numTraps = 6;
			numCameras = 4;
			minPatrolSize = 5;
			maxPatrolSize = 7;
			enemyHelpRadius = 35f;
			break;
		default:
			break;
		}
	}
}
