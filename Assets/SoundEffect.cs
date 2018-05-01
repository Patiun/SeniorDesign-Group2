using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffect : MonoBehaviour {

    public Transform noiseSphere;
    public float TimeUnitlSilent;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void OnCollisionEnter(Collision collision)
	{
        Instantiate(noiseSphere, gameObject.transform.position, Quaternion.identity);
        float scale = collision.relativeVelocity.magnitude;
        noiseSphere.transform.localScale = new Vector3(scale, scale, scale);
        Destroy(noiseSphere, TimeUnitlSilent);
	}
}
