using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorMenuButton : AbstractIconMenuButton
{
	private Door door_scr;

	private void Start()
	{
		door_scr = InteractiveObject.GetComponent<Door> ();
	}

	public override void Disable()
	{
		throw new System.NotImplementedException();
	}

	public override void Enable()
	{
		throw new System.NotImplementedException();
	}

	public override void Execute()
	{
		throw new System.NotImplementedException();
	}

	public void CallOpen() {
		door_scr.Open ();
	}

	public void CallClose() {
		door_scr.Close ();
	}

	public void CallLock() {
		door_scr.Lock ();
	}

	public void CallUnlock() {
		door_scr.Unlock ();
	}
}
