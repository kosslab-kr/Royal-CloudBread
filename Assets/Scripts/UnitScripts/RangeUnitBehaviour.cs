using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeUnitBehaviour : UnitBehaviour {
	public GameObject arrowObject;

	/*protected new void Update(){
		base.Update();
	}*/

	protected override void attack(){
		setDirection (enemy.transform.position - transform.position);
		animationControl ();

		if (timeSpent >= attackFreq) {
			GameObject newArrow = Instantiate (arrowObject);
			newArrow.transform.position = transform.position;
			newArrow.GetComponent<ArrowBehaviour> ().setTarget (enemy, ATK);

			timeSpent = 0.0f;
		}
	}
}
