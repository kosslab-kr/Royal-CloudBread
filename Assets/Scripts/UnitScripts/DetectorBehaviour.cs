using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//각 개체의 탐지 영역 정의
public class DetectorBehaviour : MonoBehaviour {
	//ObjectBase self;

	List<GameObject> enemyList;	//탐지한 적을 저장하는 리스트

	void Start () {
		//self = transform.parent.gameObject.GetComponent<ObjectBase>();	//탐지하고 있는 개체

		enemyList = new List<GameObject>();
	}

	void OnTriggerEnter2D(Collider2D other){
		print (other.gameObject);
		if (other.gameObject.CompareTag(transform.parent.gameObject.tag) == false) {
			enemyList.Add (other.gameObject);
		}
	}

	void OnTriggerExit2D(Collider2D other){
		if (enemyList.Contains(other.gameObject)) {
			enemyList.Remove (other.gameObject);
		}
	}

	public GameObject getEnemy(){
		GameObject temp = null;
		if (enemyList.Count != 0) {
			temp = enemyList [0];
			enemyList.Remove (enemyList [0]);
		}
		return temp;
	}

	/* Legacy Code
	//탐지를 끈 상태에서 다시 켬(해당 개체가 호출)
	public void restartDectecting(){
		detecting = true;
	}

	//탐지 범위 내에 있는 개체가 적이면 self가 공격하도록 함
	void OnTriggerStay2D(Collider2D other){
		if (!other.gameObject.CompareTag(self.gameObject.tag)) {
			self.changeToAttack (other.gameObject);
			detecting = false;
		}
	}*/
}
