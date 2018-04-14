using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WomenScared : MonoBehaviour {

	private AudioSource theAudio;
	private float screamtime;

	private void Start(){
		screamtime = -100f;
		theAudio = GetComponent<AudioSource> ();
	}

	private void OnTriggerEnter(Collider other){
		if (other.CompareTag("Spider")) {
			if (Time.time-screamtime >= 10) {
				theAudio.Play ();
				screamtime = Time.time;
			}
			other.GetComponent<BugChaseMan> ().Chase ();
			other.GetComponent<BugBehaviour> ().Chase ();
		}
	}
}
