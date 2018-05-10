using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LazerBehavior : MonoBehaviour {

    public bool on;
    public int minSize;
    public float scalingSpeed;

    private Vector3 baseScale;
    private Vector3 targetScale;

	// Use this for initialization
	void Start () {
        baseScale = transform.localScale;
	}
	
	// Update is called once per frame
	void Update () {
        if(on == false){
            targetScale = new Vector3(minSize, baseScale.y, minSize);
        }
        else{
            targetScale = baseScale;
            GetComponent<CapsuleCollider>().enabled = true;
        }
        if(transform.localScale != targetScale){
            transform.localScale = Vector3.Lerp(transform.localScale, targetScale, scalingSpeed * Time.deltaTime);
        }
        else{
            if(on == false){
                GetComponent<CapsuleCollider>().enabled = false;
            }
        }
	}

	void OnTriggerEnter(Collider col) {
		if (col.tag != "Enemy" && col.tag != "Bullet") {
			WorldAIHandler ws = GameObject.FindGameObjectWithTag ("GameController").GetComponent<WorldAIHandler> ();
			ws.AlertEnemies (transform.position);
		}
	}
}
