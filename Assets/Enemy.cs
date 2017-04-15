using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour {
	NavMeshAgent agent;
	// Use this for initialization
	void Start () {
		GetComponent<Renderer> ().material.color = Color.red;
		agent = GetComponent<NavMeshAgent> ();
	}
	
	// Update is called once per frame
	void Update () {
		agent.SetDestination (Player.Instance.transform.position);
	}
}
