using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TowerHPShower : MonoBehaviour {

    public Slider TowerHPbarSlider;
    public ObjectBase objectbase;

    private void Start()
    {
        TowerHPbarSlider.maxValue = objectbase.HP;
        //Debug.Log(TowerHPbarSlider.value);
    }

    private void FixedUpdate()
    {
        if (GetComponent<ObjectBase>().HP > 0)
        {
            TowerHPbarSlider.value = objectbase.HP;
            //Debug.Log(TowerHPbarSlider.value);
        }
    }
}
