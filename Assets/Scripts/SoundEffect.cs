using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffect : MonoBehaviour {

	public GameObject noiseSphere;
	public float noiseScale;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.tag != "Player") {
			GameObject obj = Instantiate (noiseSphere, gameObject.transform.position, Quaternion.identity);
			float scale = collision.impulse.magnitude*noiseScale;
			obj.transform.localScale = new Vector3 (scale, scale, scale);
		}
	}
}
