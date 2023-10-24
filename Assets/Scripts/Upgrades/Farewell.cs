using UnityEngine;
using UnityEngine.Tilemaps;

public class Farewell : MonoBehaviour
{
    private Rigidbody2D rb;
    private int speed = 10;
    private Vector3 direction;
    private int destroyCount, maximumDestroyCount = 25;

    private void UpdateDirection(Vector3 vector)
    {
        FarewellObstacles.OnInstantiate -= UpdateDirection;
        direction = vector;
    }

    private void OnEnable()
    {
        FarewellObstacles.OnInstantiate += UpdateDirection;
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) return;

        Tilemap tilemap = collision.gameObject.GetComponent<Tilemap>();
        if (tilemap != null)
        {
            // Convert world point to cell position
            for (int i = 0; i < collision.contacts.Length; i++)
            {
                Vector3Int cellPosition = tilemap.WorldToCell(collision.contacts[i].point);
                tilemap.SetTile(cellPosition, null);

                destroyCount++;
                if (destroyCount >= maximumDestroyCount)
                    Destroy(gameObject);
            }
        }
    }

    private void Update()
    {
        rb.velocity = direction * speed;
    }
}
