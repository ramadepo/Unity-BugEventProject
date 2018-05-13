using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BugBehaviour : MonoBehaviour {

	public float hp=50f;
	public bool isMom;
	public GameObject childBug;
	public GameObject SpawnPlace;

	private Animator ani;
	private float firstFirst = 15f;//10
	private float firstSecond = 25f;//15
	private float secondFirst = 3f;//25
	private float secondSecond = 8f;//35

	private void Start(){
		ani = GetComponent<Animator> ();
		if (isMom) {
			Invoke ("Spawn", Random.Range (firstFirst, firstSecond));
			ani.SetBool ("IsMom", true);
		}
	}

	public void BeAttacked(float damage){
		hp -= damage * Time.deltaTime;
	}

	public void Chase(){
		ani.SetBool ("haveChased", true);
	}

	public void Destroy(){
		Debug.Log (gameObject.name + " was dead");
		GameObject.Destroy (gameObject);
	}

	private void Update(){
		if (hp<=0) {
			ani.SetBool ("IsDead", true);
		}
	}

	private void Spawn(){
		int SpawnPlaceNum = Random.Range (0, SpawnPlace.transform.childCount);
		Instantiate (childBug, SpawnPlace.transform.GetChild (SpawnPlaceNum).position, SpawnPlace.transform.GetChild (SpawnPlaceNum).rotation);
		Debug.Log ("Spawn!!!");
		Invoke ("Spawn", Random.Range (secondFirst, secondSecond));
	}
		
}
