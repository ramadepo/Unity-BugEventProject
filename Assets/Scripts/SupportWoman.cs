using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SupportWoman : MonoBehaviour {

	public bool[] consumableList;
	public float[] supportValue;
	public bool[] unconsumableList;

	public Camera cam;
	private TextMeshProUGUI pleasePressText;
	public GameObject pleasePress;
	public HPDamagePerBug hp;

	// Use this for initialization
	void Start () {
		pleasePressText = pleasePress.GetComponent<TextMeshProUGUI> ();
		pleasePress.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void OnTriggerStay(Collider other){
		if (other.transform.tag == "SpiderTarget") {
			RaycastHit hit;
			if (Physics.Raycast(cam.transform.position,cam.transform.forward,out hit,10f)) {
				if (hit.transform.tag == "SpiderTarget") {
					pleasePress.SetActive (true);
					if (Input.GetKey(KeyCode.F)) {
						for (int i = 0; i < consumableList.Length; i++) {
							if (consumableList[i]) {
								hp.AddHP (supportValue [i]);
							}
						}
						pleasePress.SetActive (false);
					}
				} else {
					pleasePress.SetActive (false);
				}
			}
		}

	}
}
