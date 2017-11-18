using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

    private static GameController instance;

    public static GameController GetInstance()
    {
        if (instance == null)
        {
            instance = FindObjectOfType<GameController>();

            if (instance == null)
            {
                GameObject container = new GameObject("GameController");

                instance = container.AddComponent<GameController>();
            }
        }
        return instance;
    }

	public readonly float resetTime = 6.0f;		//유닛 생성에 필요한 시간
	UnitGenerator activeGen = null;				//현재 활성상태인 타워의 reference를 저장

	public readonly string playerTag = "Player";

	//현재 활성화된 Generator를 비활성화시키고 특정 Generator를 받아 활성화
	public void setGenActive(UnitGenerator genToActive)	
    {
		if (activeGen)
			activeGen.isActive = false;
		activeGen = genToActive;
    }

	//Get the currently activated generator. Used bu UI
	public UnitGenerator getActiveGen(){
		return activeGen;
	}
		
	//When gameover, enable the stop panel and stop the game
	public GameObject stopPanel;
	public Text gameOverText;
	public void gameOver(string loserTag){
		Time.timeScale = 0.0f;
		stopPanel.SetActive (true);
		if (loserTag.CompareTo (playerTag) == 0) {
			gameOverText.text = "Lose...";
			Debug.Log ("You lose...");
		} else {
			gameOverText.text = "Win!";
			Debug.Log ("You Win!");
		}
	}
}
