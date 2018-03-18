using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;                                   //Needed for navmesh

public class Enemy_NavMesh_Chase : MonoBehaviour {

    public Transform chaseGoal;                         //What enemy runs to
    private NavMeshAgent agent;

    public float health;
    public float dmgPerBullet;

	// Use this for initialization
	void Start () {
        agent = GetComponent<NavMeshAgent>();
        agent.destination = chaseGoal.position;
	}
	
	// Update is called once per frame
	void Update () {
        agent.destination = chaseGoal.position;
	}

    void OnCollisionEnter(Collision collision){
        if(collision.gameObject.tag == "AgentBullet"){
            health = health - dmgPerBullet;
            if(health <= 0){
                Death();
            }
        }
    }

    void Death(){
        Destroy(gameObject);
    }
}
