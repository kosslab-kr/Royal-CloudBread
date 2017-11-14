using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RespawnTimeShower : MonoBehaviour {
	//float value;

	//Set Time of Displayer
	public void setTime(float _value){
		//value = _value;

		GetComponentInChildren<Slider> ().value = _value;
	}
}
