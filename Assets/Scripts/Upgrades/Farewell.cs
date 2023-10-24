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
            for (int i = 0; i < collision.contacts.Length; i++)
            {
                Vector3Int cellPosition = tilemap.WorldToCell(collision.contacts[i].point);
                tilemap.SetTile(cellPosition, null);
            }
        }
    }
}
