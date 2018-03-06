using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneSwitchOnClick : MonoBehaviour
{
	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		if (Input.GetMouseButtonUp (0))
        {
			UnityEngine.SceneManagement.SceneManager.LoadScene ("map_fix");
		}
	}
}