using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

//유닛의 행동 및 속성 정의
public class UnitBehaviour : ObjectBase {
	public int num;

	protected new void Start () {
		base.Start ();

		//초기경로 설정, 초기 상태는 이동 상태
		//calculateRoute ();
		curBehavior = Behaviour.move;
		animationList = new string[]{"walk_right", "walk_down", "walk_left", "walk_up", 
									 "attack_right", "attack_down", "attack_left", "attack_up"};
		direction = 0;
	}

	protected void Update () {
		timeSpent += Time.deltaTime;	//공격 상태가 아니라도 공격 딜레이 계산은 계속 수행
		if (enemy) {
			attack ();
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
	}

	public float moveSpeed;
	public Transform waypoint;
	int direction;

	//이동(TODO: 직선 경로 이외의 경로 이동. 각 waypoint에 자식 waypoint 부여하고 이를 읽어 구현)
	protected void move(){
		Vector3 beforePos;

		if (!transform.position.Equals (waypoint)) {
			beforePos = transform.position;
			transform.position = Vector3.MoveTowards(transform.position, waypoint.transform.position, moveSpeed * Time.deltaTime);

			setDirection (transform.position - beforePos);
			animationControl ();
		}
		else {
			curBehavior = Behaviour.idle;
		}
	}

	protected void setDirection(Vector3 directionVec){
		if (System.Math.Abs (directionVec.x) > System.Math.Abs (directionVec.y)) {
			if (directionVec.x > 0.0f) {
				direction = 0;	//right
			} else {
				direction = 2;	//left
			}
		} else {
			if (directionVec.y > 0.0f) {
				direction = 3;	//up
			} else {
				direction = 1;	//down
			}
		}
	}

	protected void animationControl (){
		int index = direction;
		if (curBehavior == Behaviour.attack)
			index += 4;
		GetComponent<Animator> ().Play (animationList [index]);
	}

	//공격(TODO: 근접과 원거리로 분화, 원거리는 타워 공격 방식을 사용)
	protected virtual void attack(){
		enemy.GetComponent<ObjectBase> ().damaged (ATK);
	}

	/*
	protected void OnCollisionStay2D(Collision2D other){
		float xDiffAbs = System.Math.Abs (transform.position.x - other.transform.position.x);

		//print (xDiffAbs);
		if (xDiffAbs > 0.35f && xDiffAbs < 0.45f) {
			if (other.gameObject.transform.position.y <= transform.position.y) {
				transform.position = transform.position + new Vector3 (0.0f, Time.deltaTime, 0.0f);
			} /*else if (other.gameObject.transform.position.y < transform.position.y) {
				transform.position = transform.position + new Vector3 (0.0f, Time.deltaTime, 0.0f);
			} else {
				while (other.gameObject.transform.position.y == transform.position.y) {
					transform.position = transform.position + new Vector3 (0.0f, moveSpeed * Time.deltaTime, 0.0f);
				}
			}
		}
	}*/
}
/* Legacy Codes
  Vector3 startPosition, endPosition;
  float currentTimeOnPath, totalTimeForPath;

//경로 이동에 필요한 요소들을 계산
	protected void calculateRoute(){
		startPosition = transform.position;
		endPosition = waypoint.transform.position;

		float pathLength = Vector3.Distance(startPosition, endPosition);
		currentTimeOnPath = 0.0f;
		totalTimeForPath = pathLength / moveSpeed;
	}

	protected void move(){
		currentTimeOnPath += 1 * Time.deltaTime;
			transform.position = Vector3.Lerp (startPosition, endPosition, currentTimeOnPath / totalTimeForPath);
		//print (transform.position);

		{
			initialPosition = transform.position;
			waypoint = waypoint.transform.GetChild(0);
			currentTimeOnPath = 0;
			look(waypoint.transform.GetChild(0).position);

		}
	}
*/


/* Expreimental Codes
	void OnTriggerEnter2D(Collider2D other){
		Vector3 right = other.transform.position + new Vector3 (1.0f, 0.0f, 0.0f);
		Vector3 left = other.transform.position + new Vector3 (-1.0f, 0.0f, 0.0f);

		waypointStack.Push (waypoint);
		waypoint = new GameObject ().transform;
		if (Vector3.Distance(transform.position, left) > Vector3.Distance(transform.position, right))
			waypoint.position = right;
		else
			waypoint.position = left;
	}
*/