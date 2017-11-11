using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

    public Text unit1Displayer;
    public Text unit2Displayer;
    public Text unit3Displayer;
    public Text unit4Displayer;

    private void Update()
    {
        unit1Displayer.text = UnitDataController.GetInstance().getUnit1Num().ToString();
        unit2Displayer.text = UnitDataController.GetInstance().getUnit2Num().ToString();
        unit3Displayer.text = UnitDataController.GetInstance().getUnit3Num().ToString();
        unit4Displayer.text = UnitDataController.GetInstance().getUnit4Num().ToString();
    }
}
