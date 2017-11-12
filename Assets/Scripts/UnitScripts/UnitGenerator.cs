using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//유닛 생성기의 행동 정의
public class UnitGenerator : MonoBehaviour {
	public Transform waypoint;

	public void generateUnit(GameObject unit){
		if (unit == null)
			return;

		GameObject newUnit = Instantiate (unit);
		newUnit.transform.position = transform.position;
		newUnit.tag = string.Copy (gameObject.tag);
		newUnit.GetComponent<UnitBehaviour> ().waypoint = waypoint;
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