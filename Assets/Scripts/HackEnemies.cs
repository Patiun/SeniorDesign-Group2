using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class HackEnemies : MonoBehaviour {

	public bool isHacked = false;
	public float downTime;
	public GameObject visionFieldOfView;
	public GameObject visionNearby;
	public GameObject operatorView;

	private NavMeshAgent agent;

	// Use this for initialization
	void Start () {
		agent = gameObject.GetComponent<NavMeshAgent>();
	}
	
	// Update is called once per frame
	void Update () {
		if(isHacked == true){
			gameObject.GetComponent<Rigidbody>().useGravity = true;
			gameObject.GetComponent<Rigidbody>().isKinematic = false;
			agent.enabled = false;
			visionFieldOfView.SetActive(false);
			visionNearby.SetActive(false);
			operatorView.SetActive(false);
			StartCoroutine(hacked());
		}
	}

	IEnumerator hacked()
    {
        yield return new WaitForSeconds(downTime);
		gameObject.GetComponent<Rigidbody>().useGravity = false;
        gameObject.GetComponent<Rigidbody>().isKinematic = true;
		agent.enabled = true;
		visionFieldOfView.SetActive(true);
		visionNearby.SetActive(true);
		operatorView.SetActive(true);
		isHacked = false;
    }
}
