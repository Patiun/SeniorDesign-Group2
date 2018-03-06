using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetActiveSecurityCam : MonoBehaviour {
	public static Camera active_cam;
	public Camera render_cam;

	public void SetActiveCam() {
		if (active_cam != null) {
			active_cam.gameObject.SetActive (false);
		}
		render_cam.gameObject.SetActive (true);
		active_cam = render_cam;
	}
}
