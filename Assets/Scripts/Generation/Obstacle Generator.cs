using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ObstacleGenerator : MonoBehaviour
{
    public List<GameObject> obstacleList;
    float timer, spawnTime;

    void Update()
    {
        timer += Time.deltaTime;
        if (timer > (spawnTime - Time.deltaTime))
        {
            timer = 0;
            Instantiate(obstacleList[Random.Range(0, obstacleList.Count)], this.transform.position, Quaternion.identity);
        }
    }
}
