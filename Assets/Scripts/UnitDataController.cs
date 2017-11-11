using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitDataController : MonoBehaviour {

    private static UnitDataController instance;

    public static UnitDataController GetInstance()
    {
        if(instance == null)
        {
            instance = FindObjectOfType<UnitDataController>();

            if(instance == null)
            {
                GameObject container = new GameObject("UnitDataController");

                instance = container.AddComponent<UnitDataController>();
            }
        }
        return instance;
    }

    private int maxUnitNum = 6;
    private int[] unitNum = { 0, 0, 0, 0 };
    
    private int unit_totalNum = 0;

    public void Add_unit_num(int num)
    {
        if(unit_totalNum < maxUnitNum)
        {
            unitNum[num] += 1;
            unit_totalNum += 1;
        }
    }
    
    public void Sub_unit_num(int num)
    {
        if(unit_totalNum > 0 && unitNum[num] > 0)
        {
            unitNum[num] -= 1;
            unit_totalNum -= 1;
        }
    }
    

    public int getUnitNum(int num)
    {
        return unitNum[num];
    }
    

}
