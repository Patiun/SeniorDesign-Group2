using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySight : MonoBehaviour {

	public float sightRange;
	public float sightRadius;
	public float turnSpeed;
	public LayerMask layerMask;

	private EnemyAI eai;

	// Use this for initialization
	void Start () {
		eai = GetComponent<EnemyAI> ();
	}
	
	// Update is called once per frame
	void Update () {
		RaycastHit hit;
		//Debug.DrawRay(transform.position,transform.forward*sightRange,Color.white);
		if (Physics.SphereCast(transform.position,sightRadius,transform.forward,out hit,sightRange,layerMask.value)){
			Debug.DrawRay(transform.position,transform.forward*hit.distance,Color.yellow);
			if (hit.collider.gameObject.tag == "Player") {
				Debug.DrawRay(transform.position,transform.forward*hit.distance,Color.green);
				eai.SpottedPlayer (hit);
			}
		}
	}

	public bool LookAt(GameObject target) {
		transform.LookAt (target.transform.position);
		RaycastHit hit;
		if (Physics.Raycast (transform.position, transform.forward,out hit, sightRange, layerMask)) {
			if (hit.collider.tag == "Player") {
				return true;
			} else {
				return false;
			}
		}
		return false;
	}

	public void Investigate() {
		float angle = Random.Range (-turnSpeed, turnSpeed);
		transform.RotateAround (transform.position, transform.up, angle);
	}
}
