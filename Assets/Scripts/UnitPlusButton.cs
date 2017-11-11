using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnitPlusButton : MonoBehaviour {

    public int num;

    public void OnClick()
    {
        UnitDataController.GetInstance().Add_unit_num(num);
    }

}
