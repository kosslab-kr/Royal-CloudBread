using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class unit1SubButton : MonoBehaviour {
    

    public void OnClick()
    {
        UnitDataController.GetInstance().Sub_unit1_num();
    }

}
