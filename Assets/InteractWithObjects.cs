using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractWithObjects : MonoBehaviour {
	public LayerMask InteractableLayers;
	OutlineMirrorObject LatestInteractableObject;
//	public Text InteractableLabel;
	public OutlineMirrorObject heldObject;

	public KeyCode interactKey;

	// Update is called once per frame
	void Update () {
		RaycastHit hit;
		if (Physics.Raycast (transform.position, transform.forward, out hit, 4f, InteractableLayers)) {
			// if we see something, compare the new object to old one
			OutlineMirrorObject newObject = hit.collider.gameObject.GetComponent<OutlineMirrorObject> ();

			if (newObject != null && newObject != LatestInteractableObject) {

				// if the object is different from the old one, disable the old outline
				if (LatestInteractableObject != null) {
					LatestInteractableObject.activeOutlines = false;
				}
				LatestInteractableObject = newObject;
			} else if (LatestInteractableObject != null && LatestInteractableObject != heldObject) {
				// enable the outline if we looking at an interactable object
				LatestInteractableObject.activeOutlines = true;
				if (Input.GetKeyUp (interactKey)) {
					ConfirmInteraction (LatestInteractableObject);
				}
			}
		} else { // disable the outline of last object we saw if we no longer see anything

			if (LatestInteractableObject != null) {
				LatestInteractableObject.activeOutlines = false;
			}		
		}
	}

	private void ConfirmInteraction(OutlineMirrorObject g) {
		heldObject = g;
		heldObject.activeOutlines = false;
		Debug.Log ("You are now holding " + heldObject.gameObject.name);
	}
}
