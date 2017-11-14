using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//유닛 생성기의 행동 정의
public class UnitGenerator : MonoBehaviour {
	public Transform waypoint;
	public RespawnTimeShower timeDisplay;

	UnitDataController unitData;
	GameController gameData;

	GameObject[] genUnitList;
	int genUnitNum;
	int[] eachUnitNum;

	public bool isActive;

	void Start(){
		unitData = UnitDataController.GetInstance();
		gameData = GameController.GetInstance();

		genUnitList = new GameObject[unitData.maxUnitNum];
		for (int i = 0; i < genUnitList.Length; i++)
			genUnitList [i] = null;
		eachUnitNum = new int[unitData.unitKind];
		for (int i = 0; i < eachUnitNum.Length; i++)
			eachUnitNum [i] = 0;
		genUnitNum = 0;

		spentTime = gameData.resetTime;
		timeDisplay.setTime (spentTime);

		isActive = false;
	}

	float spentTime;
	void FixedUpdate(){
		if (isActive) {
			spentTime -= Time.deltaTime;
			timeDisplay.setTime (spentTime);
			if (spentTime < 0.0f) {
				generateUnit ();
				spentTime = gameData.resetTime;
				timeDisplay.setTime (spentTime);
				UIManager.GetInstance ().setUnitNumText ();
			}
		}
	}

	void generateUnit(){
		GameObject newUnit;

		for (int i = 0; i < genUnitNum; i++){
			//print (i); print (genUnitNum);
			newUnit = Instantiate (genUnitList[i]);
			newUnit.transform.position = transform.Find ("Unit Generation Point " + i).position;
			newUnit.tag = string.Copy (gameObject.tag);
			newUnit.GetComponent<UnitBehaviour> ().waypoint = waypoint;

			genUnitList [i] = null;
		}

		genUnitNum = 0;
		for (int i = 0; i < unitData.unitKind; i++)
			eachUnitNum [i] = 0;
	}

	public void pushGenUnit(int unitNum){
		if (genUnitNum < unitData.maxUnitNum) {
			genUnitList [genUnitNum++] = unitData.getUnitAt(unitNum);
			eachUnitNum [unitNum] += 1;
		}
	}

	public void popGenUnit(int unitNum){
		if (genUnitNum > 0) {
			int i;

			for (i = genUnitNum - 1; i >= 0; i--) {
				if (genUnitList [i] == unitData.getUnitAt(unitNum))
					break;
			}

			if (i >= 0) {
				i = i + 1;
				for (; i < genUnitNum; i++) {
					genUnitList [i - 1] = genUnitList [i];
				}
				genUnitList [genUnitNum-1] = null;

				genUnitNum -= 1;
				eachUnitNum [unitNum] -= 1;
			}
		}
	}

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