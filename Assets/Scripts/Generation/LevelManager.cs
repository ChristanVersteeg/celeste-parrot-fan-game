using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class LevelManager : MonoBehaviour
{
    public static bool moveHazards, moveGrid = true;
    [SerializeField] private TilemapCollider2D[] mapColliders;
    private float leftScreenEdge;

    // Start is called before the first frame update
    void Start()
    {
        leftScreenEdge = Camera.main.ScreenToWorldPoint(Vector3.zero).x;

        for (int i = 1; i < mapColliders.Length; i++)
        {
            mapColliders[i].enabled = false;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (mapColliders[^1].transform.position.x <= leftScreenEdge)
        {
            moveHazards = false;
            moveGrid = false;
            mapColliders[^1].enabled = true;
            mapColliders[^2].enabled = false;
        }

        if (mapColliders[1].transform.position.x <= 0 && mapColliders[2].transform.position.x > 0)
        {
            mapColliders[0].enabled = false;
            mapColliders[1].enabled = true;         
        }

        if (mapColliders[2].transform.position.x <= 0 && mapColliders[3].transform.position.x > 0)
        {
            moveHazards = true;       
            mapColliders[1].enabled = false;
            mapColliders[2].enabled = true;
        }


    }
}
