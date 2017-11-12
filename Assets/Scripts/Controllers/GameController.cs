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

	int activeTower = -1;			//현재 활성상태인 타워의 번호만을 저장, -1은 유저가 터치하기 전상태
	static float resetTime = 6.0f;
	private float[] respawnTime = new float[2];

    //private bool[] towerActive = { false, false };
    //private float checkTime;
    //private bool[] isTimeUp = { false, false };

    // Use this for initialization
    void Start () {
		for (int i = 0; i < 2; i++)
			respawnTime [i] = resetTime;
        //checkTime = 0.0f;
    }

	void FixedUpdate () {
		if (activeTower >= 0) {	//유저가 터치하기 전엔 실행되지 않음
			respawnTime [activeTower] -= Time.deltaTime;
			if (respawnTime [activeTower] <= 0.0f) {
				//Unit Generation
				for (int i = 0; i < UnitDataController.GetInstance ().getMaxUnitNum (); i++) {
					GameObject unitToGen = UnitDataController.GetInstance ().getUnitToGenerate ();
					if (unitToGen)
						transform.GetChild (i).GetComponent<UnitGenerator> ().generateUnit (unitToGen);	//각 Generator에 유닛 할당하여 생산
				}
				UnitDataController.GetInstance ().resetUnitNum ();										//Data Controller의 유닛 개수 초기화

				respawnTime [activeTower] = resetTime;
			}
		}
	}

    public float GetRespwanTime(int num)
    {
        return respawnTime[num];
    }

    public void SetTowerActive(int num)		//num만 argument로 받아서 이 번호의 타워를 활성상태로
    {
		activeTower = num;
		//TODO : 매 Active 시마다 타워 위치를 기반으로 각 generator의 위치를 변경


		/*
		for (int i = 0; i < UnitDataController.GetInstance ().getMaxUnitNum (); i++) {	//지금은 그냥 위치를 중앙기준으로 반전시킴. 타워 위치기반으로 수정 생각중
			print (transform.position.x - transform.GetChild (i).transform.position.x);
			transform.GetChild (i).transform.position 
				= new Vector3 (transform.position.x-transform.GetChild (i).transform.position.x, transform.GetChild (i).transform.position.y, 0.0f);
		}
		*/
		/*
        for(int i=0; i< towerActive.Length; i++)
        {
            if (i == num)
                towerActive[i] = isActive;
            else
                towerActive[i] = !isActive;
        }
        */
    }
}
