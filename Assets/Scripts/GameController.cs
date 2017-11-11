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
    private float resetTime = 6.0f;
    private bool[] isTimeUp = { false, false };

    // Use this for initialization
    void Start () {
        for (int i = 0; i < 2; i++)
            respawnTime[i] = 6.0f;
        checkTime = 0.0f;
        StartCoroutine(WaitForIt());
    }
	
	// Update is called once per frame
	void Update () {
		if(towerActive[0])
        {
            if(isTimeUp[0])
            {
                /*
                 * 유닛생성코드
                 */
                isTimeUp[0] = false;
            }
        }
        if(towerActive[1])
        {
            if (isTimeUp[1])
            {
                /*
                 * 유닛생성코드
                 */
                isTimeUp[1] = false;
            }
        }
	}

    IEnumerator WaitForIt()
    {
        for(int i=1; towerActive[0];)
        {
            Debug.Log("wait1");
            if (i == resetTime)
            {
                isTimeUp[0] = true;
                i = 0;
                respawnTime[0] = resetTime;
            }
            respawnTime[0]--;
            i++;
        }
        for (int j = 1; true && towerActive[1];)
        {
            if (j == resetTime)
            {
                isTimeUp[1] = true;
                j = 0;
                respawnTime[1] = resetTime;
            }
            respawnTime[1]--;
            j++;
        }

        yield return new WaitForSeconds(1.0f);
    }



    public float GetRespwanTime(int num)
    {
        return respawnTime[num];
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
        StartCoroutine(WaitForIt());
    }
}
