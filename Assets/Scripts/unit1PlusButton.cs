using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class unit1PlusButton : MonoBehaviour {
    

    public void OnClick()
    {
        UnitDataController.GetInstance().Add_unit1_num();
    }

}
