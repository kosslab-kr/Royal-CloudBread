using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnitPlusButton : MonoBehaviour {

    public int num;

    public void OnClick(){
		UnitGenerator activeGen = GameController.GetInstance ().getActiveGen ();

		if (activeGen) {
			activeGen.pushGenUnit (num);
			UIManager.GetInstance ().setUnitNumText ();
		}
    }

}
