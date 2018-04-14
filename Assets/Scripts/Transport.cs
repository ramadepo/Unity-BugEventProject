using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transport : MonoBehaviour {

	public Transform playerNext;
	private Transform player;

	private void OnTriggerEnter(Collider other){
		if (other.name == "GG") {
			GameManage.StopMode ();
			player = other.GetComponent<Transform> ();
			Invoke ("TransportPlayer", 2.5f);
		}
	}

	private void TransportPlayer(){
		player.position = playerNext.position;
		player.rotation = playerNext.rotation;
	}
}
