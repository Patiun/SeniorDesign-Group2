using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImageEffect : MonoBehaviour {
	public Material mat;

	void Start() {
		if (gameObject.GetComponent<Camera> ().targetTexture != null) {
			gameObject.GetComponent<Camera> ().targetTexture.height = Screen.height;
			gameObject.GetComponent<Camera> ().targetTexture.width = Screen.width;
		}
	}

	void OnRenderImage(RenderTexture src, RenderTexture dest) {
		Graphics.Blit (src, dest, mat);
	}
}
