using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit2PlusButton : MonoBehaviour {

    public void OnClick()
    {
        UnitDataController.GetInstance().Add_unit2_num();
    }
}
