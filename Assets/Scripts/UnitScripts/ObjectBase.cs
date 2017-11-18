using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

    //public GameObject Popup;
    //GameObject myPopup;


    protected void Start () {
		enemy = null;
		detector = transform.GetChild(0).gameObject.GetComponent<DetectorBehaviour>();
														//탐지 콜라이더

		timeSpent = attackFreq;							//처음 적 인식시 바로 공격
        
        //myPopup = Instantiate (Popup);
        //myPopup.transform.position = transform.position + new Vector3 (0.0f, 2.0f, 0.0f);
        //myPopup.SetActive (false);
    }

	public int HP;
	public int ATK;
    public bool isSliderDead = false;
	//When be damaged, decrease HP
	public virtual void damaged (int dmg){
		HP -= dmg;
		if (HP <= 0)
        {
            if(isSliderDead)
                Destroy (gameObject);
        }

		//myPopup.SetActive (true);
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