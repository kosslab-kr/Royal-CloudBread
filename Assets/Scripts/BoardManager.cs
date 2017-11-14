using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Random = UnityEngine.Random;

public class BoardManager : MonoBehaviour {

    [Serializable]
    public class Count
    {
        public int minimum;
        public int maximum;

        public Count(int min, int max)
        {
            minimum = min;
            maximum = max;
        }
    }

    //게임 보드 크기
    public int columns = 21;
    public int rows = 27;
    //벽 무작위 생성을 위한 코드
    //public Count wallCount = new Count(5, 9);
    //음식 무작위 생성을 위한 코드
    //public Count foodCount = new Count(1, 5);
    //출구 하나니까 그냥 변수로
    //public GameObject exit;
    //다른 것들은 여러개 생성할꺼니까 배열로
    public GameObject[] floorTiles;
    public GameObject[] wallTiles;
    public GameObject[] barrierTiles;
    //public GameObject[] foodTiles;
    //public GameObject[] enemyTiles;
    public GameObject[] ourTowres;
    public GameObject[] enemyTowres;
    public GameObject[] outerWallTiles;

    //hierarchy를 깔끔하게 하기위해
    private Transform boardHolder;
    private Transform ourTowerHolder;
    //private Transform enemyTowerHolder;
    /*게임판 위의 가능한 모든 다른위치들을 추적하기 위해 사용* 
     * 오브젝트가 해당 장소에 있는지 없는지 추적하는데도 사용*/
    private List<Vector3> gridPositions = new List<Vector3>();

    void InitializeList()
    {
        gridPositions.Clear();

        for(int x = 1; x< columns-1; x++)
        {
            for(int y=1; y<rows-1; y++)
            {
                gridPositions.Add(new Vector3(x, y, 0f));
            }
        }
    }


    //바깥벽과 게임 보드의 바닥을 짓기 위해 사용
    void BoardSetup()
    {
        //boardHolder를 Board라는 새로운 게임 오브젝트의 Transform과 동일하게 하고 시작
        boardHolder = new GameObject("Board").transform;

        for(int x=-1; x<columns +1; x++)
        {
            for( int y=-1; y<rows +1; y++)
            {
                GameObject toInstantiate = floorTiles[Random.Range(0, floorTiles.Length)];
                if (x == -1 || x == columns || y == -1 || y == rows)
                    toInstantiate = outerWallTiles[Random.Range(0, outerWallTiles.Length)];
                if ((y == rows / 2 && x == 0) || (y == rows / 2 && x == 10) || (y == rows / 2 && x == 20))
                    toInstantiate = barrierTiles[0];

                GameObject instance = Instantiate(toInstantiate, new Vector3(x, y, 0f), Quaternion.identity) as GameObject;
                instance.transform.SetParent(boardHolder);
            }
        }
    }
    
    void ourTowerSetup()
    {
        ourTowerHolder = new GameObject("ourTower").transform;

        for(int x=1; x<=columns; x++)
        {
            for(int y=1; y<=rows; y++)
            {
                GameObject toInstantiate;
                if (x== ((columns/2) - (columns/4)) && y== ((rows/2) - (rows/4) -1))
                {
                    toInstantiate = ourTowres[0];
                    GameObject instance = Instantiate(toInstantiate, new Vector3(x, y, 0f), Quaternion.identity) as GameObject;
                    instance.transform.SetParent(ourTowerHolder);
                }
                else if(x == ((columns / 2) + (columns / 4)) && y == ((rows / 2) - (rows / 4) -1))
                {
                    toInstantiate = ourTowres[0];
                    GameObject instance = Instantiate(toInstantiate, new Vector3(x, y, 0f), Quaternion.identity) as GameObject;
                    instance.transform.SetParent(ourTowerHolder);
                }
                else if (x == ((columns / 2)) && y == ((rows / 2) - (rows / 4) - (rows/8) -2))
                {
                    toInstantiate = ourTowres[0];
                    GameObject instance = Instantiate(toInstantiate, new Vector3(x, y, 0f), Quaternion.identity) as GameObject;
                    instance.transform.SetParent(ourTowerHolder);
                }
            }
        }
    }

    void enemyTowerSetup()
    {
        //enemyTowerHolder = new GameObject("enemyTower").transform;

        for (int x = 1; x <= columns; x++)
        {
            for (int y = 1; y <= rows; y++)
            {
                GameObject toInstantiate;
                if (x == ((columns / 2) - (columns / 4)) && y == ((rows / 2) + (rows / 4) +1))
                {
                    toInstantiate = enemyTowres[0];
                    GameObject instance = Instantiate(toInstantiate, new Vector3(x, y, 0f), Quaternion.identity) as GameObject;
                    instance.transform.SetParent(ourTowerHolder);
                }
                else if (x == ((columns / 2) + (columns / 4)) && y == ((rows / 2) + (rows / 4) +1))
                {
                    toInstantiate = enemyTowres[0];
                    GameObject instance = Instantiate(toInstantiate, new Vector3(x, y, 0f), Quaternion.identity) as GameObject;
                    instance.transform.SetParent(ourTowerHolder);
                }
                else if (x == ((columns / 2)) && y == ((rows / 2) + (rows / 4) + (rows / 8) + 2))
                {
                    toInstantiate = enemyTowres[0];
                    GameObject instance = Instantiate(toInstantiate, new Vector3(x, y, 0f), Quaternion.identity) as GameObject;
                    instance.transform.SetParent(ourTowerHolder);
                }
            }
        }
    }

    Vector3 RandomPosition()
    {
        int randomIndex = Random.Range(0, gridPositions.Count);
        Vector3 randomPosition = gridPositions[randomIndex];
        gridPositions.RemoveAt(randomIndex);
        return randomPosition;
    }

    void LayoutObjectAtRandom(GameObject[] tileArray, int minimum, int maximum)
    {
        int objectCount = Random.Range(minimum, maximum);

        for(int i=0; i<objectCount; i++)
        {
            Vector3 randomPosition = RandomPosition();
            GameObject tileChoice = tileArray[Random.Range(0, tileArray.Length)];
            Instantiate(tileChoice, randomPosition, Quaternion.identity);
        }
    }

    public void SetupScene(int level)
    {
        BoardSetup();
        //ourTowerSetup();
        //enemyTowerSetup();
        InitializeList();
        //LayoutObjectAtRandom(wallTiles, wallCount.minimum, wallCount.maximum);
        //LayoutObjectAtRandom(foodTiles, foodCount.minimum, foodCount.maximum);
        //int enemyCount = (int)Mathf.Log(level, 2f);
        //LayoutObjectAtRandom(enemyTiles, enemyCount, enemyCount);
        //Instantiate(exit, new Vector3(columns - 1, rows - 1, 0f), Quaternion.identity);
    }

}
