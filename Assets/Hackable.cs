using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
/// <summary>
/// The Hackable Component is used as a means of tagging an object as Hackable in a way that's
///  more version_control friendly than the Unity tag system. Its unity event should call the OnHack() of a second component
///  such as Hackable_Camera.
/// </summary>
public class Hackable : MonoBehaviour {
	public UnityEvent OnHackResponse;

	/// <summary>
	/// This function should be called by the HackingGazeTriggered of the hacking component on the main camera. 
	/// </summary>
	public void OnHack() {
		OnHackResponse.Invoke ();
	}
}
