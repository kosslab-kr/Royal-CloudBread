using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit3PlusButton : MonoBehaviour {

    public void OnClick()
    {
        UnitDataController.GetInstance().Add_unit3_num();
    }
}
