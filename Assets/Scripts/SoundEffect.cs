using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffect : MonoBehaviour {

	public GameObject noiseSphere;
	public float noiseScale;
	public float lockOutTime = 1.0f;
	private bool canMakeNoise;

	// Use this for initialization
	void Start () {
		StartCoroutine (WaitForFall (lockOutTime));
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
