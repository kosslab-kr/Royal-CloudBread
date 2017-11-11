using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerButton : MonoBehaviour {

    public int num;

	public void OnClick()
    {
        GameController.GetInstance().SetTowerActive(num, true);
        
    }
}
