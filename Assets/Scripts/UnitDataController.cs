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
    private int unit1_num = 0;
    private int unit2_num = 0;
    private int unit3_num = 0;
    private int unit4_num = 0;
    private int unit_totalNum = 0;

    public void Add_unit1_num()
    {
        if(unit_totalNum < maxUnitNum)
        {
            unit1_num += 1;
            unit_totalNum += 1;
        }
    }
    public void Add_unit2_num()
    {
        if (unit_totalNum < maxUnitNum)
        { 
            unit2_num += 1;
            unit_totalNum += 1;
        }
    }
    public void Add_unit3_num()
    {
        if (unit_totalNum < maxUnitNum)
        {
            unit3_num += 1;
            unit_totalNum += 1;
        }
    }
    public void Add_unit4_num()
    {
        if (unit_totalNum < maxUnitNum)
        {
            unit4_num += 1;
            unit_totalNum += 1;
        }
    }

    public void Sub_unit1_num()
    {
        if(unit_totalNum > 0 && unit1_num > 0)
        {
            unit1_num -= 1;
            unit_totalNum -= 1;
        }
    }
    public void Sub_unit2_num()
    {
        if (unit_totalNum > 0 && unit2_num >0)
        {
            unit2_num -= 1;
            unit_totalNum -= 1;
        }
    }
    public void Sub_unit3_num()
    {
        if (unit_totalNum > 0 && unit3_num > 0)
        {
            unit3_num -= 1;
            unit_totalNum -= 1;
        }
    }
    public void Sub_unit4_num()
    {
        if (unit_totalNum > 0 && unit4_num > 0)
        {
            unit4_num -= 1;
            unit_totalNum -= 1;
        }
    }

    public int getUnit1Num()
    {
        return unit1_num;
    }
    public int getUnit2Num()
    {
        return unit2_num;
    }
    public int getUnit3Num()
    {
        return unit3_num;
    }
    public int getUnit4Num()
    {
        return unit4_num;
    }

}
