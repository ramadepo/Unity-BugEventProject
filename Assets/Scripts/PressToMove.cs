using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PressToMove : MonoBehaviour {

	public static int placesCount = 0;
	public static int momsCount;
	private GameObject Moms;

	public Transform afterMove;
	private Transform beforeMove;
	public Transform momPlace;
	public GameObject pleasePress;
	public Camera cam;
	private TextMeshProUGUI pleasePressText;
	private Collider col;

	// Use this for initialization
	void Start () {
		Moms = GameObject.Find ("MomBugs");
		momsCount = Moms.transform.childCount - 1;
		placesCount++;

		pleasePressText = pleasePress.GetComponent<TextMeshProUGUI> ();
		pleasePress.SetActive (false);
		beforeMove = GetComponent<Transform> ();
		col = GetComponent<Collider> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void OnTriggerStay(Collider other){
		if (other.name == "GG") {
			RaycastHit hit;
			if (Physics.Raycast(cam.transform.position,cam.transform.forward,out hit,3f)) {
				if (hit.transform.name == gameObject.name) {
					if (beforeMove.position != afterMove.position) {
						pleasePress.SetActive (true);
						if (Input.GetKey(KeyCode.F)) {
							col.enabled = false;
							pleasePress.SetActive (false);
							if (CalculatePro()) {
								Moms.transform.GetChild (momsCount--).SetPositionAndRotation (momPlace.position, momPlace.rotation);
							}
							beforeMove.SetPositionAndRotation (afterMove.position, afterMove.rotation);
							placesCount--;
						}
					}
				} else {
					pleasePress.SetActive (false);
				}
			}
		}

	}

	private void OnTriggerExit(Collider other){
		if (other.name == "GG") {
			pleasePress.SetActive (false);
		}
	}

	private bool CalculatePro(){
		if (momsCount >= 0) {
			int temp;
			temp = Random.Range (1, placesCount + 1);
			if (temp <= momsCount+1) {
				return true;
			} else {
				return false;
			}
		} else {
			return false;
		}

	}

}
