using UnityEngine;
using System.Collections;
using System.Collections.Generic;

//Start State keeps track of the status of all gameObjects and components on start, then reset will revert them to how they were at startup.
public class StartState
{
	StartState[] childStates;
	MonoBehaviour[] behaviours;

	Dictionary<int, bool> enabledMonos = new Dictionary<int, bool>();
	public bool objectEnabled;
	GameObject gameObject;

	public StartState(GameObject _gameObject)
    {
		gameObject = _gameObject;
		Transform trans = _gameObject.transform;
		behaviours = gameObject.GetComponents<MonoBehaviour>();

		for (int i = 0; i < behaviours.Length; ++i)
        {
			enabledMonos.Add (behaviours[i].GetInstanceID(), behaviours [i].enabled);
		}

		objectEnabled = gameObject.activeSelf;

		childStates = new StartState[trans.childCount];

		for (int j = 0; j < childStates.Length; ++j)
        {
			childStates[j] = new StartState(trans.GetChild(j).gameObject);
		}
	}

	public void Reset()
    {
		foreach (MonoBehaviour mB in behaviours)
        {
            // Set the enabled to whatever it was in the scene
			mB.enabled = enabledMonos[mB.GetInstanceID()];
		}
        
        // Enable or disable the game objects
		gameObject.SetActive(objectEnabled);
		foreach (StartState ss in childStates)
        {
			ss.Reset();
		}
	}
}