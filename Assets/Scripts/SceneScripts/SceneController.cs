using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour {
	public string escapeScene;
	public Alert alert;
	
	void Update () {
		//Consider Android only
		if (Application.platform == RuntimePlatform.Android) {
			if (Input.GetKey (KeyCode.Escape)) {		
				if (alert) {							//If alert screen exists, make it active
					alert.setAlertActive ();
				} else {								//Else, quit app or move to the other scene
					if (escapeScene.CompareTo ("Exit") == 0) {
						Application.Quit ();
					} else {
						SceneManager.LoadScene (escapeScene);
					}
				}
			}
		}
	}
}
