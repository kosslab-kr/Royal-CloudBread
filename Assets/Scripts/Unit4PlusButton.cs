using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit4PlusButton : MonoBehaviour {

    public void OnClick()
    {
        UnitDataController.GetInstance().Add_unit4_num();
    }
}
