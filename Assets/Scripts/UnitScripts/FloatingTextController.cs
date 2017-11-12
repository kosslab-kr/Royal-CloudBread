using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingTextController : MonoBehaviour {
	public static FloatingText popupText;
	public static GameObject canvas;

	// Use this for initialization
	void Start () {
		canvas = GameObject.Find ("Canvas");
		//popupText = ;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
