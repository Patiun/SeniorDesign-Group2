using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinCanvasBehavior : MonoBehaviour {

	public string userPrompt;
	public string[] prompts;
	public float timeBtwKeys;
	public float timeForNewLine;
	public GameObject[] textBoxes;

	private int promptIndex;
	private string contents;
	private bool next;
	private bool acceptKeyPress;

	// Use this for initialization
	void Start () {
		for (int i = 0; i < textBoxes.Length;i++){
			textBoxes[i].GetComponent<UnityEngine.UI.Text>().text = "";
		}
	}

	private void Awake(){
		acceptKeyPress = false;
		next = false;
		promptIndex = 0;
		StartCoroutine(AnimateText());
	}

	IEnumerator AnimateText(){
		contents = userPrompt;
		for (int i = 0; i < prompts[promptIndex].Length; i++){
			contents = contents + prompts[promptIndex][i];
			textBoxes[promptIndex].gameObject.GetComponent<UnityEngine.UI.Text>().text = contents;
			yield return new WaitForSeconds(timeBtwKeys);
		}
		if(promptIndex < (prompts.Length -1)){
			textBoxes[promptIndex+1].gameObject.GetComponent<UnityEngine.UI.Text>().text = userPrompt;
		}
		yield return new WaitForSeconds(timeForNewLine);
		next = true;
	}

	// Update is called once per frame
	void Update () {
		if(next == true){
			if (promptIndex < (prompts.Length - 1))
			{
				promptIndex++;
				next = false;
				StartCoroutine(AnimateText());
			}
			else if (promptIndex == prompts.Length - 1)
			{
				acceptKeyPress = true;
				contents = userPrompt;
				textBoxes[textBoxes.Length-1].gameObject.GetComponent<UnityEngine.UI.Text>().text = contents;
				if (Input.GetKeyDown(KeyCode.Y))
				{
					contents = contents + "Y";
					textBoxes[textBoxes.Length - 1].gameObject.GetComponent<UnityEngine.UI.Text>().text = contents;
					nextLevel();
					next = false;
				}
				else if (Input.GetKeyDown(KeyCode.N))
				{
					contents = contents + "N";
					textBoxes[textBoxes.Length - 1].gameObject.GetComponent<UnityEngine.UI.Text>().text = contents;
					menu();
					next = false;
				}
			}
		}
	}

	void nextLevel(){
		Debug.Log("NEXTLEVEL");
	}

	void menu(){
		SceneManager.LoadScene(0);
	}

}
