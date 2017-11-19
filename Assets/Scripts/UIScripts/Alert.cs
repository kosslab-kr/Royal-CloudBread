using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Alert : MonoBehaviour {
	float beforeTimescale;
	public void setAlertActive(){
		gameObject.SetActive (true);
		if (Time.timeScale != 0.0f)
			beforeTimescale = Time.timeScale;
		Time.timeScale = 0.0f;
	}

	public void onYesButtonClicked(string scene){
		if (scene.CompareTo ("Exit") == 0) {
			Application.Quit ();
		} else {
			Time.timeScale = beforeTimescale;
			SceneManager.LoadScene (scene);
		}
	}

	public void onNoButtonClicked(){
		Time.timeScale = beforeTimescale;
		gameObject.SetActive (false);
	}
}
