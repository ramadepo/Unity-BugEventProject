using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PostProcessing;

public class SpiderManage : MonoBehaviour {

	public PostProcessingBehaviour camEffects;
	public PostProcessingProfile CC;
	public PostProcessingProfile RR;
	public int bugCount = 0;



	private void Update(){
		if (bugCount == 0) {
			camEffects.profile = CC;
		} else {
			camEffects.profile = RR;
		}
	}

	public void AddBug(){
		bugCount++;
	}

	public void KillBug(){
		bugCount--;
	}

}
