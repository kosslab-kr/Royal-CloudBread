using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TowerHPShower : MonoBehaviour {

    public Slider TowerHPbarSlider;
    public TowerBehaviour towerbehaviour;

    private void Start()
    {
        TowerHPbarSlider.maxValue = towerbehaviour.HP;
        //Debug.Log(TowerHPbarSlider.value);
    }

    private void FixedUpdate()
    {
        if (GetComponent<TowerBehaviour>().HP > 0)
        {
            TowerHPbarSlider.value = towerbehaviour.HP;
            //Debug.Log(TowerHPbarSlider.value);
        }
        if(GetComponent<TowerBehaviour>().HP <= 0)
        {
            TowerHPbarSlider.gameObject.SetActive(false);
            GetComponent<TowerBehaviour>().isSliderDead = true;
        }
    }
}
