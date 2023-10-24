using UnityEngine;
using UnityEngine.Tilemaps;

public class Farewell : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) return;

        Tilemap tilemap = collision.gameObject.GetComponent<Tilemap>();
        if (tilemap != null)
        {
            // Convert world point to cell position
            Vector3Int cellPosition = tilemap.WorldToCell(collision.contacts[0].point);

            // Erase the tile at the given cell position
            tilemap.SetTile(cellPosition, null);
        }
    }
}
