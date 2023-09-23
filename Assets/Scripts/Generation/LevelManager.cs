using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class LevelManager : MonoBehaviour
{
    public static bool moveHazards;
    [SerializeField] private TilemapCollider2D[] mapColliders;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 1; i < mapColliders.Length; i++)
        {
            mapColliders[i].enabled = false;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(mapColliders[1].transform.position.x <= 0)
        {
            mapColliders[1].enabled = true;
            mapColliders[0].enabled = false;
        }

        if (mapColliders[2].transform.position.x <= 0)
        {
            moveHazards = true;
            mapColliders[2].enabled = true;
            mapColliders[1].enabled = false;
        }
    }
}
