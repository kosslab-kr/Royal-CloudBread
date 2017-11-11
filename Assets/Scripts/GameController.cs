using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

    
    private static GameController instance;

    public static GameController GetInstance()
    {
        if (instance == null)
        {
            instance = FindObjectOfType<GameController>();

            if (instance == null)
            {
                GameObject container = new GameObject("GameController");

                instance = container.AddComponent<GameController>();
            }
        }
        return instance;
    }

    private bool[] towerActive = { false, false };
    private float[] respawnTime = new float[2];
    private float checkTime;
    private float resetTime = 6;
    private bool[] isTimeUp = { false, false };

    // Use this for initialization
    void Start () {
        for (int i = 0; i < 2; i++)
            respawnTime[i] = 6.0f;
        checkTime = 0.0f;
    }
	
	// Update is called once per frame
	void Update () {
	}

    private void FixedUpdate()
    {
        if(towerActive[0])
        {
            respawnTime[0] -= Time.deltaTime;
            if(respawnTime[0] <=0)
            {
                /*
                 * 유닛생성코드
                 */
                respawnTime[0] = 6.0f;
            }
        }
        else if(towerActive[1])
        {
            respawnTime[1] -= Time.deltaTime;
            if (respawnTime[1] <= 0)
            {
                /*
                 * 유닛생성코드
                 */
                respawnTime[1] = 6.0f;
            }
        }
    }


    public float GetRespwanTime(int num)
    {
        return respawnTime[num];
    }

    public bool[] GetTowerActiveArr()
    {
        return towerActive;
    }

    public void SetTowerActive(int num, bool isActive)
    {
        for(int i=0; i< towerActive.Length; i++)
        {
            if (i == num)
                towerActive[i] = isActive;
            else
                towerActive[i] = !isActive;
        }
    }
}
