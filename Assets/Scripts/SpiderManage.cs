using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PostProcessing;

public class SpiderManage : MonoBehaviour {

	public PostProcessingProfile CC;
	private VignetteModel.Settings vvset;
	private float redTime;
	private bool reding;

	private void Start(){
		redTime = -100f;
		reding = false;
	}

	private void Update(){
		vvset = CC.vignette.settings;
		if (bugCount > 0) {
			if (Time.time-redTime >= 4.5f) {	//count for when reder and when blacker
				reding = true;
				redTime = Time.time;
			}
		}
		if (reding) {
			Reder ();
		} else {
			Blacker ();
		}
		if (SpiderManage.bugCount == 0) {	//reset vignette
			vvset.color.r = 0f;
			reding = false;
			CC.vignette.settings = vvset;
		}
	}

	public static int bugCount = 0;

	public static void AddBug(){
		bugCount++;
	}

	public static void MinusBug(){
		bugCount--;
		if (bugCount < 0) {
			bugCount = 0;
		}
	}

	public static void KillBug(){
		bugCount--;
		if (bugCount < 0) {
			bugCount = 0;
		}
	}

	private void Reder(){	//red vignette
		if (vvset.color.r < 1f) {
			vvset.color.r += 0.3922f * Time.deltaTime;
		}
		else {
			vvset.color.r = 1f;
			reding = false;
		}
		CC.vignette.settings = vvset;
	}

	private void Blacker(){	//return normal vignette
		if (vvset.color.r > 0f) {
			vvset.color.r -= 0.3922f * Time.deltaTime;
		} else {
			vvset.color.r = 0f;
		}
		CC.vignette.settings = vvset;
	}

}
