﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//유닛 생성기의 행동 정의
public class UnitGenerator : MonoBehaviour {
	public Transform waypoint;
	public RespawnTimeShower timeDisplay;	//Time Displayer defined in RespawnTimeShower

	//Reference of singletons(globals)
	UnitDataController unitData;
	GameController gameData;

	//Information of units to generate
	GameObject[] genUnitList;
	int genUnitNum;
	int[] eachUnitNum;

	//State of generator
	public bool isActive;

	//Initialize
	void Start(){
		//Get Referenece of globals
		unitData = UnitDataController.GetInstance();
		gameData = GameController.GetInstance();

		//Initialize unit generation list, number of each and total units
		genUnitList = new GameObject[unitData.maxUnitNum];
		for (int i = 0; i < genUnitList.Length; i++)
			genUnitList [i] = null;
		eachUnitNum = new int[unitData.unitKind];
		for (int i = 0; i < eachUnitNum.Length; i++)
			eachUnitNum [i] = 0;
		genUnitNum = 0;

		//Initialize timer. Intialize time displayer if it exists
		spentTime = gameData.resetTime;
		if (timeDisplay) timeDisplay.setTime (spentTime);

		//Set initial state(inactive)
		isActive = false;
	}

	//Check timer and generate units when reset time expired
	float spentTime;
	void FixedUpdate(){
		//Check only if this generator is active
		if (isActive) {
			spentTime -= Time.deltaTime;
			if (timeDisplay) timeDisplay.setTime (spentTime);

			//Generate units in the list when the reset time expired
			if (spentTime < 0.0f) {
				generateUnit ();
				UIManager.GetInstance ().setUnitNumText ();
				//issue: time Display와 unit number의 UI가 분리되어 버려서 UI관련 함수를 2번 호출함
				//기존처럼 UI manager를 통한 관리? Generator가 unit number text도 참조하도록?

				//Reset time
				spentTime = gameData.resetTime;
				if (timeDisplay) timeDisplay.setTime (spentTime);
			}
		}
	}

	//Generate units in list
	void generateUnit(){
		GameObject newUnit;	//Used for unit instantiation

		for (int i = 0; i < genUnitNum; i++){
			newUnit = Instantiate (genUnitList[i]);
			newUnit.transform.position = transform.Find 
					("Unit Generation Point " + i).position;	//Find unit generation point, which is a child of tower
			newUnit.tag = string.Copy (gameObject.tag);			//Copy tag from the generator to team identification
			newUnit.GetComponent<UnitBehaviour> ().waypoint = waypoint;	//Copy the waypoint referenced by the generator

			genUnitList [i] = null;
		}

		//Increase total/each unit number
		genUnitNum = 0;
		for (int i = 0; i < unitData.unitKind; i++)
			eachUnitNum [i] = 0;
	}

	//Add an unit to list, units identified by index
	public void pushGenUnit(int unitNum){
		if (genUnitNum < unitData.maxUnitNum) {
			genUnitList [genUnitNum++] = unitData.getUnitAt(unitNum);
			eachUnitNum [unitNum] += 1;
		}
	}

	public void pushGenUnit(GameObject unitToPush){
		if (genUnitNum < unitData.maxUnitNum) {
			genUnitList [genUnitNum++] = unitToPush;
		}
	}

	//Remove the specific one unit in the list
	public void popGenUnit(int unitNum){
		if (eachUnitNum [unitNum] > 0) {
			int i;

			//Find that unit
			for (i = genUnitNum - 1; i >= 0; i--) {
				if (genUnitList [i] == unitData.getUnitAt(unitNum))
					break;
			}

			//Remove the unit and reorder the list
			if (i >= 0) {
				i = i + 1;
				for (; i < genUnitNum; i++) {
					genUnitList [i - 1] = genUnitList [i];
				}
				genUnitList [genUnitNum-1] = null;

				//Decrease total/each unit number
				genUnitNum -= 1;
				eachUnitNum [unitNum] -= 1;
			}
		}
	}

	//Get each number of unit. Used by UI
	public int getUnitNum(int unitNum){
		return eachUnitNum[unitNum];
	}
}

/* Legacy Codes
 	static float OFFSET = 16.0f;
	float timeSpent = 0.0f;
	float checkTime = 6.0f;


	//일정 시간마다 할당된 유닛 생성
	void FixedUpdate () {
		GameObject newUnit;

		timeSpent += Time.deltaTime;
		if (timeSpent > checkTime) {
			float xoffset = -OFFSET;
			float yoffset = -OFFSET;

			for (int i = 0; i < units.Length; i++) {
				int temp = dummyUnitArray [i];
				while (temp != 0) {
					newUnit = Instantiate (units [i]);
					newUnit.transform.position = transform.position + new Vector3 (xoffset, yoffset, 0);
					newUnit.tag = string.Copy (gameObject.tag);
					newUnit.GetComponent<UnitBehaviour> ().waypoint = waypoint;
					//newUnit.transform.position += new Vector3 (xoffset, yoffset, 0);

					xoffset += OFFSET;
					if (xoffset > OFFSET) {
						xoffset = -OFFSET;
						yoffset = 0.0f;
					}
					temp--;
				}
			}

			timeSpent = 0.0f;
		}
	}
*/