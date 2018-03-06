using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

using XRInput = UnityEngine.XR.InputTracking;

public class GazeScript1 : MonoBehaviour {
	public Camera gazeCam;
	public float secondsUntilGaze = 3f;
	public LayerMask _gazeLayerMask;

	GazeResponder potential_gr;
	GazeResponder previous_gr;
	private float continuous_time = 0f;

	// Use this for initialization
	void Start () {

	}


	// Update is called once per frame
	void Update () {
		RaycastHit hit;
		// do a Physics raycast directly forward from center of the camera. 
		// If it hits something in its mask:
		if (Physics.Raycast (gazeCam.transform.position, gazeCam.transform.forward, out hit, 100f, _gazeLayerMask)) {

			// Check that the object hit is a GazeResponder.
			potential_gr = hit.collider.gameObject.GetComponent<GazeResponder> ();
//			if (!potential_gr) {
//				if 
//				potential_gr = hit.collider.gameObject.GetComponentInChildren<ConversationButton> ();
//			}
			// If it is:
			if (potential_gr && !potential_gr.inactive) {
				UIManager.instance.Reticle_parent.transform.localScale = Vector3.Slerp (UIManager.instance.Reticle_parent.transform.localScale, new Vector3 (1.4f, 1.4f, 1.4f), .3f);
				// If we've been looking at this continuously:
				if (potential_gr == previous_gr) {
					continuous_time += Time.deltaTime;
					// If we have been looking at this long enough to qualify as a Gaze action:
					float progressRingFill = (continuous_time/secondsUntilGaze);
					UIManager.instance.Reticle_inner.GetComponent<Image>().fillAmount = progressRingFill;
					if (continuous_time >= secondsUntilGaze) {
						UIManager.instance.Reticle_parent.transform.localScale = Vector3.Slerp (UIManager.instance.Reticle_parent.transform.localScale, new Vector3 (1f, 1f, 1f), .3f);
						Debug.Log ("Gaze Triggered on " + hit.collider.gameObject.name);
						// Notify the GazeResponder and tell it to, uh, respond.
						UIManager.instance.Reticle_inner.GetComponent<Image>().fillAmount = 0f;
						continuous_time = 0f;
						potential_gr.Invoke ();
					}

					// If we haven't been looking at this continuously: 
				} else {
					continuous_time = 0f;
					UIManager.instance.Reticle_inner.GetComponent<Image>().fillAmount = 0f;

					previous_gr = potential_gr;
//					Debug.Log ("i see a gazresponder " + hit.collider.gameObject.name);
				}					
			} else {

				// If no valid gaze responder was seen
				continuous_time = 0f;
				UIManager.instance.Reticle_inner.GetComponent<Image>().fillAmount = 0f;
				UIManager.instance.Reticle_parent.transform.localScale = Vector3.Slerp (UIManager.instance.Reticle_parent.transform.localScale, new Vector3 (1f, 1f, 1f), .3f);
			}
				

//			if (hit.collider.gameObject.tag.Equals ("friend")) {
////				reticle.color = Color.green;
//			} else if (hit.collider.gameObject.tag.Equals ("dialogButton")) {
////				reticle.color = Color.cyan;
//			} else {
//				reticle.transform.localScale = Vector3.one;
//			}

		// If it doesn't hit something:
		} else {
			continuous_time = 0f;
			UIManager.instance.Reticle_inner.GetComponent<Image>().fillAmount = 0f;
			UIManager.instance.Reticle_parent.transform.localScale = Vector3.Slerp (UIManager.instance.Reticle_parent.transform.localScale, new Vector3 (1f, 1f, 1f), .3f);
		}

////		Debug.Log (results.Count);
//		foreach (RaycastResult r in results) {
//			if (r.gameObject.GetComponent<GazeResponder> ()) {
//			} else { 
//				Debug.Log ("Not a gaze responder " + r.gameObject.name);
//			}
//		}	
	}
}

