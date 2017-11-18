using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerButton : MonoBehaviour {
	public UnitGenerator assignedGen;

	/*void Start(){
		//assignedGen = transform.parent.gameObject.GetComponent<UnitGenerator>();
		print (transform.position);
	}*/

	public void OnClick()
    {
		//Make the assigned generator acitve if it exists, and let the controller know it.
		if (assignedGen && assignedGen.enabled) {
			GameController.GetInstance ().setGenActive (assignedGen);
			assignedGen.isActive = true;
			UIManager.GetInstance ().setUnitNumText ();
		}
    }
}
