using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//유닛 생성기의 행동 정의
public class UnitGenerator : MonoBehaviour {
	public GameObject unit;
	public Transform waypoint;

	private float timeSpent;
	float checkTime;
	//int unitNumber = 0;

	void Start () {
		timeSpent = 0.0f;
		checkTime = 1.0f;
	}
	
	//일정 시간마다 할당된 유닛 생성
	void Update () {
		GameObject newUnit;

		timeSpent += Time.deltaTime;
		if (timeSpent > checkTime) {
			newUnit = Instantiate (unit);
			newUnit.transform.position = transform.position;
			newUnit.tag = string.Copy (gameObject.tag);
			newUnit.GetComponent<UnitBehaviour> ().waypoint = waypoint;

			//unitNumber += 1;
			timeSpent = 0.0f;
		}
	}
}
