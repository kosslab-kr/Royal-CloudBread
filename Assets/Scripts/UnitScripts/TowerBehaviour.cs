using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//타워의 행동 및 속성 정의
public class TowerBehaviour : ObjectBase {
	public GameObject arrowObject;
	public float arrowSpeed;

	new void Start () {
		base.Start ();
		curBehavior = Behaviour.idle;	//타워는 이동하지 않음
	}
		
	protected void Update () {
		timeSpent += Time.deltaTime;	//공격 상태가 아니라도 공격 딜레이 계산은 계속 수행
		if (enemy) {
			//공격 딜레이가 끝나면 공격
			if (timeSpent >= attackFreq) {
				attack ();
				timeSpent = 0.0f;
			}
		} else {
			enemy = detector.getEnemy ();
			if (curBehavior == Behaviour.attack && !enemy) {
				curBehavior = beforeBehavior;
			} else if (enemy){
				beforeBehavior = curBehavior;
				curBehavior = Behaviour.attack;
			}

		}
	}

	//Arrow를 생성하여 공격
	void attack(){
		GameObject newArrow = Instantiate (arrowObject);
		newArrow.transform.position = transform.position;
		newArrow.GetComponent<ArrowBehaviour> ().setTarget (enemy, ATK, arrowSpeed);
	}
}
