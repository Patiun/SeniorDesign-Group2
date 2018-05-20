using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinCanvasBehavior : MonoBehaviour {

	public string userPrompt;
	public string[] prompts;
	public float timeBtwKeys;
	public float timeForNewLine;
	public GameObject[] textBoxes;

	private int promptIndex;
	private string contents;
	private bool next;

	// Use this for initialization
	void Start () {
	}

	private void Awake(){
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
		}
	}
}
