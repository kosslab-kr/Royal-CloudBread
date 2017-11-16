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
		
	public readonly float resetTime = 6.0f;	//유닛 생성에 필요한 시간
	UnitGenerator activeGen = null;				//현재 활성상태인 타워의 reference를 저장

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
}

/* Legacy Codes
 
    //private bool[] towerActive = { false, false };
	//private float checkTime;
	//private bool[] isTimeUp = { false, false };

	
	for (int i = 0; i < UnitDataController.GetInstance ().getMaxUnitNum (); i++) {	//지금은 그냥 위치를 중앙기준으로 반전시킴. 타워 위치기반으로 수정 생각중
		print (transform.position.x - transform.GetChild (i).transform.position.x);
		transform.GetChild (i).transform.position 
			= new Vector3 (transform.position.x-transform.GetChild (i).transform.position.x, transform.GetChild (i).transform.position.y, 0.0f);
	}
		
	for(int i=0; i< towerActive.Length; i++)
	{
		if (i == num)
			towerActive[i] = isActive;
		else
			towerActive[i] = !isActive;
	}

	private float[] respawnTime = new float[2];

    void Start () {
		for (int i = 0; i < 2; i++)
			respawnTime [i] = resetTime;
        //checkTime = 0.0f;
    }


	public UnitGenerator activeGen;
	void FixedUpdate () {
		if (activeTower >= 0) {	//유저가 터치하기 전엔 실행되지 않음
			respawnTime [activeTower] -= Time.deltaTime;
			if (respawnTime [activeTower] <= 0.0f) {
				//Unit Generation
				generator.generateUnit();

				respawnTime [activeTower] = resetTime;
			}
		}
	}

    public float GetRespwanTime(int num)
    {
        return respawnTime[num];
    }

	public bool isTowerActive(int num){
		if (activeTower == num)
			return true;
		else
			return false;
	}
*/