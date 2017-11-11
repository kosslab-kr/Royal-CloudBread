using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit2SubButton : MonoBehaviour {

    public void OnClick()
    {
        UnitDataController.GetInstance().Sub_unit2_num();
    }
}
