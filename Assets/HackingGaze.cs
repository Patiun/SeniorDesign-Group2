using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HackingGaze : MonoBehaviour {
	public float HackingPercentComplete = 0f;
	public float TimeToHack = 3f;
	public float HackRange = 10f;
	public KeyCode HackingButton;
	public LayerMask hackingRaycastLayerMask;
	public GameObject ReticleMask;

	private bool currently_hacking = false;
	private float currentTimeSpentHacking = 0f;
	private GameObject targetedHackableObject;

	void Start() {
		if (ReticleMask == null) {
			Debug.LogError ("Add a reference to ReticleMask from inside the reticle canvas object to this script to enable visualizing Hacking Progress.");
		}
	}

	// Update is called once per frame
	void Update () {
		ReticleMask.GetComponent<Image> ().fillAmount = HackingPercentComplete;
		// check if the button to begin hacking has been pressed
		// @Greg here's the input for the hack action
		if (Input.GetKeyDown (HackingButton)) {
			if (GetTargetedObject () != null && GetTargetedObject().GetComponent<Hackable> () != null) {
				currentTimeSpentHacking = 0f;
				currently_hacking = true;
				targetedHackableObject = GetTargetedObject ();
			}
		}
			

		// if we are currently hacking
		if (currently_hacking) {
			// stop hacking when they let go of the button, or if they begin targeting a different object (or nothing)
			// @Greg here's the input for the hack action
			if (!Input.GetKey (HackingButton)  || GetTargetedObject() != targetedHackableObject) {
				currently_hacking = false;
				HackingPercentComplete = 0f;
			} else {
				currentTimeSpentHacking += Time.deltaTime;
				HackingPercentComplete = currentTimeSpentHacking / TimeToHack;
				if (currentTimeSpentHacking >= TimeToHack) {
					targetedHackableObject.GetComponent<Hackable> ().OnHack ();
					currently_hacking = false;
					HackingPercentComplete = 0f;
				}
			}
		}

	}

	private GameObject GetTargetedObject () {
		RaycastHit hit;
		if (Physics.Raycast (transform.position, transform.forward, out hit, HackRange, hackingRaycastLayerMask)) {
			if (hit.collider.gameObject.GetComponent<Hackable> () != null) {
				return hit.collider.gameObject;
			} else {
				return null;
			}
		} else {
			return null;
		}

	}
}
