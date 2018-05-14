using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundFunctionality : MonoBehaviour {

	public float timeLimit = .5f;
	private float count = 0;
	private List<GameObject> enemies;
	private GameObject closestEnemy;
	// Use this for initialization
	void Start () {
		enemies = new List<GameObject>();
		closestEnemy = null;
	}
	
	// Update is called once per frame
	void Update () {
		if (count >= timeLimit)
		{
			float minDistance = -1;
			for (int i = 0; i < enemies.Count; i++)
			{
				if (i == 0)
				{
					minDistance = Vector3.Distance(transform.position, enemies[0].transform.position);
					closestEnemy = enemies[0].gameObject;
				}
				else
				{
					float dist = Vector3.Distance(transform.position, enemies[i].transform.position);
					if (dist < minDistance)
					{
						minDistance = dist;
						closestEnemy = enemies[i].gameObject;
					}
				}
			}
			if (closestEnemy != null) {
    			EnemyAI brain = closestEnemy.GetComponent<EnemyAI>();
    			brain.MinorActivity(transform.position);
		    }
			Destroy (this.gameObject);
		} else {
			count += Time.deltaTime;
		}
	}

	public void OnTriggerEnter(Collider col) {
		if(col.tag == "Enemy" && col.isTrigger == false){
			enemies.Add(col.gameObject);
		}
	}
}
