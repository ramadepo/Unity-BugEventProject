using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BugChaseMan : MonoBehaviour {

	private SpiderManage manager;

	private Transform Destination;
	private NavMeshAgent navMeshAgent;
	private BugBehaviour bugBe;
	private bool haveChased = false;

	// Use this for initialization
	void Start () {
		manager = GameObject.Find ("SpiderManager").GetComponent<SpiderManage> ();
		bugBe = GetComponent<BugBehaviour> ();
		navMeshAgent = GetComponent<NavMeshAgent> ();
		Destination = GameObject.FindWithTag ("SpiderTarget").transform;
	}
	
	// Update is called once per frame
	void Update () {
		if (bugBe.hp <= 0) {
			if (haveChased) {
				haveChased = false;
				manager.KillBug ();
			}
			Component.Destroy (navMeshAgent);
		} else {
			navMeshAgent.SetDestination (Destination.position);
		}
	}

	public void Chase(){
		if (!haveChased) {
			manager.AddBug ();
			haveChased = true;
		}
	}
}
