using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour {
	public string escapeScene;
	
	void Update () {
		if (Application.platform == RuntimePlatform.Android) {
			if (Input.GetKey (KeyCode.Escape)) {
				if (escapeScene.CompareTo ("Exit") == 0) {
					Application.Quit ();
				}
				else{
					SceneManager.LoadScene(escapeScene);
				}
			}
		}
	}
}
