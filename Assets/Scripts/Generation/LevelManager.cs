using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class LevelManager : MonoBehaviour
{
    public static bool moveHazards, moveGrid = true, moveVertical, moveHorizontal= true;
    [SerializeField] private TilemapCollider2D[] mapColliders;
    private float leftScreenEdge, topScreenEdge;
    public static int currentLevel;

    // Start is called before the first frame update
    void Start()
    {
        leftScreenEdge = Camera.main.ScreenToWorldPoint(Vector3.zero).x;
        topScreenEdge = Camera.main.ScreenToWorldPoint(new Vector3(0, 400, 0)).y;

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
            currentLevel = mapColliders.Length;
            moveHazards = false;
            moveGrid = false;
            mapColliders[^1].enabled = true;
            mapColliders[^2].enabled = false;
        }

        if (mapColliders[1].transform.position.x <= 0 && mapColliders[2].transform.position.x > 0) //forsaken city to old site
        {
            currentLevel = 1;
            mapColliders[0].enabled = false;
            mapColliders[1].enabled = true;         
        }

        if (mapColliders[2].transform.position.x <= 0 && mapColliders[3].transform.position.x > 0) //old site to celestial resort
        {
            currentLevel = 2;
            moveHazards = true;       
            mapColliders[1].enabled = false;
            mapColliders[2].enabled = true;
        }

        if (mapColliders[3].transform.position.x <= leftScreenEdge)
        {
            currentLevel = 3;
            moveHazards = true;
            moveHorizontal = false;
            moveVertical = true;
            mapColliders[2].enabled = false;
            mapColliders[3].enabled = true;
        }
        Debug.Log(mapColliders[4].name);
        if (mapColliders[4].transform.position.y <= topScreenEdge)
        {
            currentLevel = 4;
            moveHazards = false;
            moveHorizontal = true;
            moveVertical = false;
            mapColliders[3].enabled = false;
            mapColliders[4].enabled = true;
        }
    }

    private void OnDisable()
    {
        moveHazards = false;
    }
}
