using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;                                   //Needed for navmesh

public class Enemy_NavMesh_Chase : MonoBehaviour {

    public Transform chaseGoal;                         //What enemy runs to
    private NavMeshAgent agent;

	// Use this for initialization
	void Start () {
        agent = GetComponent<NavMeshAgent>();
        agent.destination = chaseGoal.position;
	}
	
	// Update is called once per frame
	void Update () {
        agent.destination = chaseGoal.position;
	}
}
