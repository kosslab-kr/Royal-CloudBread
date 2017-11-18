using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicUnitBehaviour : UnitBehaviour {
	public GameObject arrowObject;
	public float arrowSpeed;
    public AudioSource audioSource;

	GameObject[] enemys = {null, null, null};
	int enemy_count;

	protected new void Update () {
		timeSpent += Time.deltaTime;	//공격 상태가 아니라도 공격 딜레이 계산은 계속 수행

		//매 프레임마다 적의 개수 및 목록을 갱신(최대 3타겟)
		enemy_count = 0;
		for (int i = 0; i < 3; i++) {
			if (!enemys [i]) {
				enemys [i] = detector.getEnemy ();
				if (enemys [i])
					enemy_count += 1;
			} else
				enemy_count += 1;
		}

		if (enemy_count > 0) {
			if (curBehavior != Behaviour.attack) {
				beforeBehavior = curBehavior;
				curBehavior = Behaviour.attack;
			}

			//공격 딜레이가 끝나면 공격
			if (timeSpent >= attackFreq) {
				attack ();
				timeSpent = 0.0f;
			}
		} else {
			if (curBehavior == Behaviour.attack) {	
				curBehavior = beforeBehavior;
			} else if (curBehavior == Behaviour.move){
				move ();
			}
		}
	}

	protected override void attack(){
		GameObject newArrow;

		for (int i = 0; i < 3; i++) {
			if (enemys [i]) {
				setDirection (enemys[i].transform.position - transform.position);
				animationControl ();

				newArrow = Instantiate (arrowObject);
				newArrow.transform.position = transform.position;
				newArrow.GetComponent<ArrowBehaviour> ().setTarget (enemys [i], ATK, arrowSpeed);
                SoundManager.instance.MagicAttack();
			}
		}
	}
}

