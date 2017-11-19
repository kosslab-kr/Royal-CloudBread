using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Facebook.Unity;
using UnityEngine.SceneManagement;

public class LogoutCotroller : MonoBehaviour {

	public void logout(){
		FB.LogOut ();
		StartCoroutine ("checkIfLogout");
	}

	IEnumerator checkIfLogout(){
		if (FB.IsLoggedIn) {
			yield return new WaitForSeconds (0.1f);
			StartCoroutine ("checkIfLogout");
		} else
			print ("logout!");

	}
}
