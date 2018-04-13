using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MomBugNumberTextBehaviour : MonoBehaviour {

	public GameObject tran;
	private bool isEnd = false;

	public GameObject Moms;
	private int momSum;
	private TextMeshProUGUI momNumberText;

	// Use this for initialization
	void Start () {
		momSum = Moms.transform.childCount;
		momNumberText = GetComponent<TextMeshProUGUI> ();
	}
	
	// Update is called once per frame
	void Update () {
		momNumberText.text = Moms.transform.childCount.ToString () + " / " + momSum.ToString ();
	}
}
