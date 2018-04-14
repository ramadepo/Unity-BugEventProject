using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class GameManage : MonoBehaviour {

	public static bool canControl;
	public static Flowchart flow;


	// Use this for initialization
	void Start () {
		canControl = false;
		flow = GameObject.Find ("FadeFlowChart").GetComponent<Flowchart> ();
		flow.FindBlock ("FadeOut").StartExecution ();
	}
	
	public static void ManualMode(){
		canControl = true;
	}

	public void ManualJump(){
		GameManage.ManualMode ();
	}

	public static void StopMode(){
		canControl = false;
		flow.FindBlock ("FadeIn").StartExecution ();
	}

}
