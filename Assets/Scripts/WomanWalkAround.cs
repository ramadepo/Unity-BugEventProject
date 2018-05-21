using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WomanWalkAround : MonoBehaviour {

	public GameObject WalkToPlace;
	private int PlaceNum;
	private NavMeshAgent nav;
	public float time1 = 20f;
	public float time2 = 40f;
	public Animator ani;

	// Use this for initialization
	void Start () {
		nav = GetComponent<NavMeshAgent> ();
		Invoke ("Walk", Random.Range (10f, 20f));
	}

	void Update(){
		if (Vector3.Distance(transform.position,WalkToPlace.transform.GetChild(PlaceNum).position) <= 1.5f) {
			ani.SetBool ("IsWalking", false);
		}
	}

	private void Walk(){
		ani.SetBool ("IsWalking", true);
		PlaceNum = Random.Range (0, WalkToPlace.transform.childCount);
		nav.SetDestination (WalkToPlace.transform.GetChild (PlaceNum).position);
		Invoke ("Walk", Random.Range (time1, time2));
	}
}
