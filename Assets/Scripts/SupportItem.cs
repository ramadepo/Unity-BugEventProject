using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SupportItem : MonoBehaviour {

	public float supportValue;
	public int number;
	public bool consumable;


	public Camera cam;
	private TextMeshProUGUI pleasePressText;
	public GameObject pleasePress;

	// Use this for initialization
	void Start () {
		pleasePressText = pleasePress.GetComponent<TextMeshProUGUI> ();
		pleasePress.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void OnTriggerStay(Collider other){
		if (other.name == "GG") {
			RaycastHit hit;
			if (Physics.Raycast(cam.transform.position,cam.transform.forward,out hit,3f)) {
				if (hit.transform.name == gameObject.name) {
					pleasePress.SetActive (true);
					if (Input.GetKey(KeyCode.F)) {
						pleasePress.SetActive (false);
						if (consumable) {
							other.GetComponent<SupportWoman> ().consumableList [number] = true;
							other.GetComponent<SupportWoman> ().supportValue [number] = supportValue;
						} else {
							other.GetComponent<SupportWoman> ().unconsumableList [number] = true;
						}
						gameObject.SetActive (false);
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

}
