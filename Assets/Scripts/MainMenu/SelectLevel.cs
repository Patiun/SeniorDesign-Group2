using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectLevel : MonoBehaviour {

	public MainMenuBehavior mainMenuBehavior;
	public int SceneIndex;
	public bool isEnabled;
	public Material downMaterial;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    
	private void OnMouseDown()
	{
		if (isEnabled == true)
		{
			Renderer ren = gameObject.GetComponent<Renderer>();
			ren.material = downMaterial;
			mainMenuBehavior.closeDoors(SceneIndex);
		}
	}
}
