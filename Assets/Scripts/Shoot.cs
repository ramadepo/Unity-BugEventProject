using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shoot : MonoBehaviour {

	public float damage = 25f;
	public float range = 3f;
	public Camera cam;
	public Slider powerSlider;
	public ParticleSystem waterSmoke;
	private float powerValue;
	private float spraySpeed = 20f;
	private float maxPower = 100f;
	private Animator ani;

	// Use this for initialization
	void Start () {
		powerValue = maxPower;
		ani = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		Spray ();
		Reload ();
		powerSlider.value = powerValue;
	}

	public void clientReload(int reloadNum){
		if (powerValue + reloadNum > maxPower) {
			powerValue = maxPower;
		} else {
			powerValue += reloadNum;
		}
	}

	private void Reload(){
		if (powerValue < maxPower) {
			powerValue += 5f * Time.deltaTime;
		} else {
			powerValue = maxPower;
		}
	}

	private void Spray(){
		if (!GameManage.canControl) {
			return;
		}
		if (Input.GetButtonDown("Fire1")) {
			ani.SetBool ("IsShooting", true);

		}
		if (Input.GetButton("Fire1")) {
			if (powerValue > 1f) {
				powerValue -= spraySpeed * Time.deltaTime;
				waterSmoke.Play ();
				RaycastHit hit;
				if (Physics.Raycast(cam.transform.position,cam.transform.forward,out hit,range)) {
					Debug.Log (hit.transform.name);
					BugBehaviour target = hit.transform.GetComponent<BugBehaviour> ();
					if (target != null) {
						Debug.Log ("123");
						target.BeAttacked (damage);
					}
				}
			} else {
				powerValue = 0f;
				waterSmoke.Stop ();
			}
		}
		if (Input.GetButtonUp("Fire1")) {
			ani.SetBool ("IsShooting", false);
			waterSmoke.Stop ();
		}
	}
}
