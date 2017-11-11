using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//모든 개체의 공통기능 및 속성 정의
public class ObjectBase : MonoBehaviour {
	protected enum Behaviour { move, attack, idle };

	protected GameObject enemy;
	protected DetectorBehaviour detector;
	protected Behaviour curBehavior;
	protected Behaviour beforeBehavior; 
	protected string[] animationList;

	public float attackFreq;
	protected float timeSpent;
	//NavMeshAgent agent;

	protected void Start () {
		enemy = null;
		detector = transform.GetChild(0).gameObject.GetComponent<DetectorBehaviour>();
														//탐지 콜라이더

		timeSpent = attackFreq;							//처음 적 인식시 바로 공격
	}

	public int HP;
	public int ATK;

	//데미지 입음
	public void damaged (int dmg){
		HP -= dmg;
		Debug.Log (dmg + " point damaged to" + enemy);
		if (HP <= 0) {
			Destroy (gameObject);
			Debug.Log ("destroyed!");
		}
	}


	/* Legacy Code
	//적 인식 시 공격 상태로 변경
	public void changeToAttack(GameObject _enemy){
		enemy = _enemy;
		beforeBehavior = curBehavior;
		curBehavior = Behaviour.attack;
	}
	*/
}