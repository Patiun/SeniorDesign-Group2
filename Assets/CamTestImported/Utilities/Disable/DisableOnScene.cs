using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class DisableOnScene : MonoBehaviour
{
	public string SceneName;
	public GameObject gO;

    // Add this OnLevelWasLoaded function to the sceneLoaded listener
    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoad;
    }

    // Remove this script's function from the scene listener
    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoad;
    }

    // Use this for initialization
    void OnSceneLoad(Scene scene, LoadSceneMode mode)
    {
		if (scene.name == SceneName)
        {
			gO.SetActive(false);
		}
        else
        {
			gO.SetActive(true);
		}
	}
}