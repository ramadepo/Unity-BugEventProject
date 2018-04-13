using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PowerText : MonoBehaviour {

	private TextMeshProUGUI powerText;

	private void Start(){
		powerText = GetComponent<TextMeshProUGUI> ();
	}

	public void ChangePowerText(float newValue){
		powerText.text = newValue.ToString () + "%";
	}
}
