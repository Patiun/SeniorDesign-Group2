using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

using XRInput = UnityEngine.XR.InputTracking;

public class GazeScript : MonoBehaviour {
	public Image reticle;
	public Camera gazeCam;
	public float secondsUntilGaze = 3f;
	public GameObject debugBall;
	public LayerMask _gazeLayerMask;
	public UnityEvent onGaze;
	public GraphicRaycaster gRaycaster;
	bool called = false;

	private float secondsSpentGazing = 0f;
	private GameObject mostRecentHit  = null;
	private GraphicRaycaster g;


	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		PointerEventData pointerData = new PointerEventData(EventSystem.current);
		List<RaycastResult> results = new List<RaycastResult>();
		pointerData.position = new Vector2 (Screen.width * 0.5f, Screen.height * 0.5f);
		EventSystem.current.RaycastAll(pointerData, results);
		bool UIhit = false;
		foreach (RaycastResult r in results) {
			if (r.gameObject.tag.Equals ("dialogButton")) {
				Debug.Log ("looking at dialogButton");
				reticle.color = Color.cyan;
				UIhit = true;
				if (mostRecentHit != null &&
					mostRecentHit.GetInstanceID () == r.gameObject.GetInstanceID ()) {
					secondsSpentGazing += Time.deltaTime;
					if (secondsSpentGazing >= secondsUntilGaze && !called) {
						Debug.Log ("Gaze action triggered on " + r.gameObject.name);
						onGaze.Invoke ();
						called = true;
					}
				} else {
					mostRecentHit = r.gameObject;
					secondsSpentGazing = Time.deltaTime;
					called = false;
				}
				Debug.Log ("mostRecentHit = " + mostRecentHit);
			}
		}	
	if (!UIhit) {
			RaycastHit hit;

			if (Physics.Raycast (gazeCam.transform.position, gazeCam.transform.forward, out hit, 100f, _gazeLayerMask)) {
				if (hit.collider.gameObject.tag.Equals ("friend")) {
					reticle.color = Color.green;

					if (mostRecentHit != null &&
					   mostRecentHit.GetInstanceID () == hit.collider.gameObject.GetInstanceID ()) {
						secondsSpentGazing += Time.deltaTime;
						if (secondsSpentGazing >= secondsUntilGaze && !called) {
							Debug.Log ("Gaze action triggered on " + hit.collider.gameObject.name);
//							hit.collider.gameObject.GetComponent<GazeTarget> ().RespondToGaze();
							secondsSpentGazing = 0f;
						}
					} else {
						mostRecentHit = hit.collider.gameObject;
						secondsSpentGazing = 0f;
						called = false;
					}
				} else if (!hit.collider.gameObject.tag.Equals ("debug")) {
	//				Debug.Log ("Gazing  at " + hit.collider.gameObject.name + " tagged: " + hit.collider.gameObject.tag);
					reticle.color = Color.white;
				}

			} else {
				reticle.color = Color.white;
			}
		}
	}
}
