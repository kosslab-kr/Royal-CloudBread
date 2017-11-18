using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeUnitBehaviour : UnitBehaviour {
	public GameObject arrowObject;
	public float arrowSpeed;

	/*protected new void Update(){
		base.Update();
	}*/

	protected override void attack(){
		setDirection (enemy.transform.position - transform.position);
		animationControl ();

		if (timeSpent >= attackFreq) {
			GameObject newArrow = Instantiate (arrowObject);
			newArrow.transform.position = transform.position;
			newArrow.GetComponent<ArrowBehaviour> ().setTarget (enemy, ATK, arrowSpeed);

			timeSpent = 0.0f;
		}
	}
}
