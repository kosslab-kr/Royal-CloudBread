using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RespawnTimeShower : MonoBehaviour {
	public int towerNum;

	void Start(){
		GetComponentInChildren<Slider> ().value = GameController.resetTime;
		//GetComponentInChildren<Text>().text = GameController.resetTime.ToString("N1");
	}

	void FixedUpdate () {
		if (GameController.GetInstance ().isTowerActive(towerNum)){
			GetComponentInChildren<Slider> ().value = GameController.GetInstance ().GetRespwanTime (towerNum);
			//GetComponentInChildren<Text>().text = GameController.GetInstance ().GetRespwanTime (towerNum).ToString("N1);
		}

    }
}
