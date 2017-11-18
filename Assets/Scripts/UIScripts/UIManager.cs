using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {
	private static UIManager instance;

	public static UIManager GetInstance()
	{
		if (instance == null)
		{
			instance = FindObjectOfType<UIManager>();

			if (instance == null)
			{
				GameObject container = new GameObject("UIManager");

				instance = container.AddComponent<UIManager>();
			}
		}
		return instance;
	}

    public Text[] unitDisplayer;
	int unitKind;

	void Start(){
		unitKind = UnitDataController.GetInstance ().unitKind;
			
		//unitDisplayer = new Text[unitKind];
		for (int i = 0; i < unitKind; i++)
			unitDisplayer [i].text = "0";
	}

    public void setUnitNumText(){
		if (GameController.GetInstance ().getActiveGen ()) {
			for (int i = 0; i < unitKind; i++)
				unitDisplayer [i].text = 
				GameController.GetInstance ().getActiveGen ().getUnitNum (i).ToString ();
		}
    }
}
