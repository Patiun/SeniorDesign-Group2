using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class DisableScriptOnLoad : MonoBehaviour
{
	public MonoBehaviour mono;
	public string SceneName;

    // Add a scene-change listener for OnLevelWasLoaded
    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoad;
    }

    // Remove the listener
    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoad;
    }

    void OnSceneLoad(Scene scene, LoadSceneMode mode)
    {
		if (SceneManager.GetActiveScene().name == SceneName)
        {
			mono.enabled = false;
		}
        else
        {
			mono.enabled = true;
		}
	}
}