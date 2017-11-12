using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//투사체의 행동 및 속성 정의
public class ArrowBehaviour : MonoBehaviour {
	GameObject target;
	int atk;
	public float speed;

	bool tracking = false;

	//투사체를 생성하는 개체로부터 타겟과 공격력을 받아옴
	public void setTarget(GameObject _target, int _atk){
		target = _target;
		atk = _atk;
		tracking = true;
	}
		
	void Update () {
		if (target) 
			goToTarget ();			//타겟으로 이동
		else if (tracking)
			Destroy (gameObject);	//타겟이 소멸되었을 경우 투사체도 소명
	}

	//타겟을 추적하여 이동
	void goToTarget(){
		transform.position = Vector3.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);

		//타겟에 접근했을 경우 데미지를 주고 소멸
		if (Vector3.Distance(transform.position, target.transform.position) <= 0.1f) {
			target.GetComponent<ObjectBase> ().damaged (atk);
			Destroy (gameObject);
		}
	}
}
