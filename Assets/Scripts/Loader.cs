using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loader : MonoBehaviour {

    public GameObject gameMnanager;
    
	void Awake () {
        if (GameManager.instance == null)
            Instantiate(gameMnanager);
	}
	
}
