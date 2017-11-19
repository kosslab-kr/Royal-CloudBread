using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Facebook.Unity;



public class LoginButton : MonoBehaviour {
    public void OnClickButton()
    {
		var perms = new List<string>(){"public_profile", "email", "user_friends"};
		FB.LogInWithReadPermissions(perms, AuthCallback);
    }

	private void AuthCallback(ILoginResult result){
		if (FB.IsLoggedIn) {
			//AccessToken class will have session details
			var aToken = Facebook.Unity.AccessToken.CurrentAccessToken;
			//Print current access token's User ID
			Debug.Log(aToken.UserId);
			//Print current access token's granted permissions
			foreach (string perm in aToken.Permissions) {
				Debug.Log (perm);
			}

			SceneManager.LoadScene("Menu");
		} else {
			Debug.Log ("User cancelled login");
		}
	}
}
