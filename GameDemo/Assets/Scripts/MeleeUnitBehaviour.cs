using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeUnitBehaviour : UnitBehaviour {
	/*protected new void Update () {
		timeSpent += Time.deltaTime;	//공격 상태가 아니라도 공격 딜레이 계산은 계속 수행
		if (enemy) {
			if (Vector3.Distance (transform.position, enemy.transform.position) > 1.0f) {	//근접 유닛은 
				transform.position = Vector3.MoveTowards (transform.position, enemy.transform.position, moveSpeed * Time.deltaTime);
			}
			else if (timeSpent >= attackFreq) {		//공격 딜레이가 끝나면 공격
				attack ();
				timeSpent = 0.0f;
			}
		} else {
			enemy = detector.getEnemy ();
			if (curBehavior == Behaviour.attack) {
				if (!enemy) {
					//calculateRoute ();
					curBehavior = beforeBehavior;
				}
			} else{
				if (enemy) {
					beforeBehavior = curBehavior;
					curBehavior = Behaviour.attack;
				}
				else if (curBehavior == Behaviour.move)
					move ();
			}

		}
	}*/

	protected override void attack(){
		setDirection (enemy.transform.position - transform.position);

		if (Vector3.Distance (transform.position, enemy.transform.position) > 0.7f) {	//근접 유닛은 적에게 근접할때까지 공격하지 못함
			transform.position = Vector3.MoveTowards (transform.position, enemy.transform.position, moveSpeed * Time.deltaTime);
		} else if (timeSpent >= attackFreq) {											//공격 딜레이가 끝나면 공격
			enemy.GetComponent<ObjectBase> ().damaged (ATK);
			animationControl ();

			timeSpent = 0.0f;
		}
	}
}
