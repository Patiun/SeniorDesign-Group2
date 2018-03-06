using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.Events;

[System.Serializable]
public struct ButtonData {
	public string value;
	public UnityEvent action;
}

public class UIManager : Singleton<UIManager>
{
	// Currently accessed directly by GazeScript, but not used in any DialogUIManager functions. (I wanted to make sure 
	//  everything UI related flows through here)
	public GameObject Reticle_parent;
	public GameObject Reticle_inner;

	// Use this for initialization
	void Start ()
	{
	}
}

