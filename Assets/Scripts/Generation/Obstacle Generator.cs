using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ObstacleGenerator : MonoBehaviour
{
    public List<GameObject> bottomObstacleList;
    public List<GameObject> topObstacleList;
    public Transform topSpawner, bottomSpawner;
    private int incrementor = 0;
    WaitForSeconds spawnTime = new(2.0f);
    public void Start()
    {
        StartCoroutine(Spawner());
    }

    private IEnumerator Spawner()
    {
        while (true)
        {          
            if (incrementor % 2 == 0)
            {
                Instantiate(bottomObstacleList[Random.Range(0, bottomObstacleList.Count)], bottomSpawner.position, Quaternion.identity);
                incrementor++;
            }
            else
            {         
                Instantiate(topObstacleList[Random.Range(0, topObstacleList.Count)], topSpawner.position, Quaternion.identity);
                incrementor++;
            }

            yield return spawnTime;
        }
    }
}

