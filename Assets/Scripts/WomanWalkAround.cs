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

	// Use this for initialization
	void Start () {
		nav = GetComponent<NavMeshAgent> ();
		Invoke ("Walk", Random.Range (10f, 20f));
	}
	
	private void Walk(){
		PlaceNum = Random.Range (0, WalkToPlace.transform.childCount);
		nav.SetDestination (WalkToPlace.transform.GetChild (PlaceNum).position);
		Invoke ("Walk", Random.Range (time1, time2));
	}
}
