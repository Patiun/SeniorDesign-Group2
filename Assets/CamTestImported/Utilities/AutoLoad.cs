using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class AutoLoad : MonoBehaviour
{
	public string levelName;

	// Use this for initialization
	void Start()
    {
		if (levelName != "")
        {
			SceneManager.LoadScene(levelName);
		}
	}
}