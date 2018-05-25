using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChooseRandomLevel : MonoBehaviour {

	public int[] sceneIndexs;

	public void OnClick() {
		int rand = Random.Range (0, sceneIndexs.Length);
		SceneManager.LoadScene (sceneIndexs[rand]);
	}
}
