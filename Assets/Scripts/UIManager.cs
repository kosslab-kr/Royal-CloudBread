using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

    public Text unit1Displayer;
    public Text unit2Displayer;
    public Text unit3Displayer;
    public Text unit4Displayer;
    public Text respwanTime1;
    public Text respwanTime2;

    private void Update()
    {
        unit1Displayer.text = UnitDataController.GetInstance().getUnitNum(0).ToString();
        unit2Displayer.text = UnitDataController.GetInstance().getUnitNum(1).ToString();
        unit3Displayer.text = UnitDataController.GetInstance().getUnitNum(2).ToString();
        unit4Displayer.text = UnitDataController.GetInstance().getUnitNum(3).ToString();

        respwanTime1.text = GameController.GetInstance().GetRespwanTime(0).ToString();
        respwanTime2.text = GameController.GetInstance().GetRespwanTime(1).ToString();
    }
}
