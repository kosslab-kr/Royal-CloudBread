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
	public static int maxUnitNum = 6;
	public static int unitKind = 4;

	public GameObject[] units = new GameObject[unitKind];
	List<GameObject> generationList = new List<GameObject>();

    private int[] unitNum = { 0, 0, 0, 0 };
    private int unit_totalNum = 0;

	void Start(){
		for (int i = 0; i < unitKind; i++)
			units [i].GetComponent<UnitBehaviour> ().num = i;
	}

    public void Add_unit_num(int num)
    {
        if(unit_totalNum < maxUnitNum)
        {
            unitNum[num] += 1;
            unit_totalNum += 1;

			generationList.Add (units [num]);
        }
    }
    
    public void Sub_unit_num(int num)
    {
        if(unit_totalNum > 0 && unitNum[num] > 0)
        {
            unitNum[num] -= 1;
            unit_totalNum -= 1;

			int i = generationList.Count - 1;
			while (i >= 0) {
				if (generationList [i] == units [num]) {
					generationList.RemoveAt (i);
					break;
				}
				i--;
			}
			if (i < 0)
				Debug.Log ("Errror: Thr unit doesn't exist in the list");
        }
    }
    

    public int getUnitNum(int num)
    {
        return unitNum[num];
    }

	public GameObject getUnitToGenerate(){
		GameObject unit;
		if (generationList.Count != 0) {
			unit = generationList [0];
			generationList.RemoveAt (0);

			//Decrese each unit number and total unit number to generate
			unit_totalNum--;
			unitNum [unit.GetComponent<UnitBehaviour> ().num]--;
		} else
			unit = null;

		return unit;

	}
	/*
	public void resetUnitNum(){
		for (int i = 0; i < unitKind; i++)
			unitNum [i] = 0;
		unit_totalNum = 0;
	}*/
}
