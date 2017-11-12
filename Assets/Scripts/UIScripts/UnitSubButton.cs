using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnitSubButton : MonoBehaviour {

    public int num;

    public void OnClick()
    {
        UnitDataController.GetInstance().Sub_unit_num(num);
    }

}
