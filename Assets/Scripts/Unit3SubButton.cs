﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit3SubButton : MonoBehaviour {

    public void OnClick()
    {
        UnitDataController.GetInstance().Sub_unit3_num();
    }
}
