using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderManage : MonoBehaviour {

	public int bugCount = 0;

	public void AddBug(){
		bugCount++;
	}

	public void KillBug(){
		bugCount--;
	}

}
