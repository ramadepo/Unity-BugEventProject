using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BugChaseMan : MonoBehaviour {


	private Transform Destination;
	private NavMeshAgent navMeshAgent;
	private BugBehaviour bugBe;
	private bool haveChased = false;
	private int randGo;

	// Use this for initialization
	void Start () {
		bugBe = GetComponent<BugBehaviour> ();
		navMeshAgent = GetComponent<NavMeshAgent> ();
		Destination = GameObject.FindWithTag ("SpiderTarget").transform;
		randGo = Random.Range (0, 101);
		if (0 <= randGo && randGo <= 75) {
			navMeshAgent.SetDestination (GameObject.Find ("SpawnPlace").transform.GetChild (Random.Range (0, GameObject.Find ("SpawnPlace").transform.childCount)).position);
		}
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
			if (randGo > 75) {
				navMeshAgent.SetDestination (Destination.position);
			}
		}
	}

	public void Chase(){
		if (!haveChased) {
			SpiderManage.AddBug ();
			haveChased = true;
		}
	}

	public void notChase(){
		SpiderManage.MinusBug ();
		haveChased = false;
	}
}
