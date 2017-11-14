using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnitSubButton : MonoBehaviour {

    public int num;

    public void OnClick(){
		UnitGenerator activeGen = GameController.GetInstance ().getActiveGen ();

		if (activeGen) {
			activeGen.popGenUnit (num);
			UIManager.GetInstance ().setUnitNumText ();
		}
    }

}
