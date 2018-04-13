using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WomenScared : MonoBehaviour {

	void OnTriggerEnter(Collider other){
		if (other.CompareTag("Spider")) {
			other.GetComponent<BugChaseMan> ().Chase ();
			other.GetComponent<BugBehaviour> ().Chase ();
		}
	}
}
