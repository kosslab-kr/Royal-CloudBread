using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit4SubButton : MonoBehaviour {

    public void OnClick()
    {
        UnitDataController.GetInstance().Sub_unit4_num();
    }
}
