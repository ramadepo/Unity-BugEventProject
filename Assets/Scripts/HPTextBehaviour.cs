using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class HPTextBehaviour : MonoBehaviour {

	private TextMeshProUGUI hptext;
	public Image hpBar;

	// Use this for initialization
	void Start () {
		hptext = GetComponent<TextMeshProUGUI> ();
	}
	
	// Update is called once per frame
	void Update () {
		hptext.text = (hpBar.fillAmount * 1000).ToString ();
	}
}
