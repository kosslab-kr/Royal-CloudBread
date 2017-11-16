using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerButton : MonoBehaviour {

    //public int num;
	public UnitGenerator assignedGen;

	/*void Start(){
		assignedGen = transform.parent.gameObject.GetComponent<UnitGenerator>();
	}*/

	public void OnClick()
    {
		GameController.GetInstance ().SetGenActive (assignedGen);
		assignedGen.isActive = true;
		UIManager.GetInstance ().setUnitNumText ();
    }
}
