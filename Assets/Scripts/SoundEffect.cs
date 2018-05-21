using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffect : MonoBehaviour {

	public GameObject noiseSphere;
	public float noiseScale;
	private bool canMakeNoise;

	// Use this for initialization
	void Start () {
		StartCoroutine (WaitForFall (2.0f));
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void OnCollisionEnter(Collision collision)
	{
		if (canMakeNoise) {
			if (collision.gameObject.tag != "Player" && collision.gameObject.tag != "Enemy") {
				GameObject obj = Instantiate (noiseSphere, gameObject.transform.position, Quaternion.identity);
				float scale = collision.impulse.magnitude * noiseScale;
				obj.transform.localScale = new Vector3 (scale, scale, scale);
			}
		}

	}

	IEnumerator WaitForFall(float time){
		yield return new WaitForSeconds(time);
		canMakeNoise = true;
	}
}
