using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIController : MonoBehaviour
{
    UnitGenerator activeGen;


	//The list of enemy units and the weight of them(weighted random generaton)
    public GameObject[] enemyUnits = new GameObject[2];
    public int[] unitGenWeight = new int[2];

	//The list of enemy unit generator, number of towers(generator), 
	//										and index of activated genrator
    public UnitGenerator[] enemyGenList = new UnitGenerator[2];
    int enemyTowerNum = 2;
    int activeEnemyGenNum;

	float resetTime = GameController.GetInstance().resetTime;

    void Start()
    {
		//Initilize the first activated tower(generator)
		activeEnemyGenNum = 0;
		for (int i = 0; i < UnitDataController.GetInstance ().maxUnitNum; i++) {
			enemyGenList [activeEnemyGenNum].pushGenUnit(seletctUnit());
		}
		enemyGenList[activeEnemyGenNum].isActive = true;

        spentTime = resetTime + 0.01f;
    }

    float spentTime;
    void FixedUpdate()
	{
		spentTime -= Time.deltaTime;
		if (spentTime < 0.0f) {
			if (enemyGenList [(activeEnemyGenNum + 1) % enemyTowerNum]) {
				enemyGenList [activeEnemyGenNum].isActive = false;

				activeEnemyGenNum = (activeEnemyGenNum + 1) % enemyTowerNum;
				enemyGenList [activeEnemyGenNum].isActive = true;
				for (int i = 0; i < UnitDataController.GetInstance ().maxUnitNum; i++) {
					enemyGenList [activeEnemyGenNum].pushGenUnit (seletctUnit ());
				}
			}

			spentTime = resetTime;
		}
	}

	GameObject seletctUnit()
	{
		//가중치에 따른 랜덤으로 리스트에서 유닛 하나 골라서 리턴
		//이걸 pushUnit
		int sum = 0;
		for (int i = 0; i < unitGenWeight.Length; i++) {
			sum += unitGenWeight [i];
		}

		int randomNum = Random.Range (0, sum - 1);
		for (int i = 0; i < unitGenWeight.Length; i++) {
			if (randomNum < unitGenWeight [i])
				return enemyUnits [i];
			randomNum -= unitGenWeight [i];
		}
		
		Debug.Log("Weighted random calculation error!!");
		return null;
	}
       

        /*TODO: 타워가 파괴되면 생산권한을 본진에 넘기는걸 어떻게 구현?
         1. 버튼을 public으로 등록해서 끝나면 acitve? : 더럽다
         2. 자식으로 등록해서 끝나면 active? : 부모가 deactive됐는데 자식이 active될수가 있나??
         3. 위치를 이동하고 assignedGen을 변경? assignedGen은 whendestroyed등으로 넘겨놓고....:
            상대적으로 낫지만 결국 public써야하는건 똑같고 버튼의 위치이동이 무난히 가능한가??

         */
    }