using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RespawnTimeBar : MonoBehaviour {

    public Slider respawnTimeBar1;
    public Slider respawnTimeBar2;

    void Start()
    {
    }
	
	// Update is called once per frame
	void Update () {
        if(GameController.GetInstance().GetTowerActiveArr()[0])
        {
            if (respawnTimeBar1.value > 0)
            {
                respawnTimeBar1.value -= Time.deltaTime;
            }
            else
            {
                respawnTimeBar1.value = 6.0f;
            }
        }
        else if (GameController.GetInstance().GetTowerActiveArr()[1])
        {
            if (respawnTimeBar2.value > 0)
            {
                respawnTimeBar2.value -= Time.deltaTime;
            }
            else
            {
                respawnTimeBar2.value = 6.0f;
            }
        }

    }
}
