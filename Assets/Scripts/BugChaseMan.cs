using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BugChaseMan : MonoBehaviour {


	private Transform Destination;
	private NavMeshAgent navMeshAgent;
	private BugBehaviour bugBe;
	private bool haveChased = false;

	// Use this for initialization
	void Start () {
		bugBe = GetComponent<BugBehaviour> ();
		navMeshAgent = GetComponent<NavMeshAgent> ();
		Destination = GameObject.FindWithTag ("SpiderTarget").transform;
	}
	
	// Update is called once per frame
	void Update () {
		if (bugBe.hp <= 0) {
			if (haveChased) {
				haveChased = false;
				SpiderManage.KillBug ();
			}
			Component.Destroy (navMeshAgent);
		} else {
			navMeshAgent.SetDestination (Destination.position);
		}
	}

	public void Chase(){
		if (!haveChased) {
			SpiderManage.AddBug ();
			haveChased = true;
		}
	}
}
