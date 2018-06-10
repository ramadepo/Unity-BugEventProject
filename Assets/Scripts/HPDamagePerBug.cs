using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPDamagePerBug : MonoBehaviour {


	private float HP = 1000;
	private Image hpBar;
	private float bugDamage = 5f;

	// Use this for initialization
	void Start () {
		hpBar = GetComponent<Image> ();
	}

	// Update is called once per frame
	void Update () {
		BugHit ();
		hpBar.fillAmount = float.Parse ((HP / 1000).ToString ("F3"));
	}

	private void BugHit(){
		if (HP > 0) {
			HP -= bugDamage * SpiderManage.bugCount * Time.deltaTime;
		} else {
			HP = 0;
		}
	}

	public void AddHP(float value){
		HP += value;
		if (HP > 1000f) {
			HP = 1000f;
		}
	}
}
