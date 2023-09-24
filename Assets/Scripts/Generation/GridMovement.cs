using UnityEngine;

public class GridMovement : MonoBehaviour
{
    public static float baseScrollSpeedX = -0.1f;
    public static float baseScrollSpeedY = -0.05f;
    public static Vector3 scrollSpeed = new(baseScrollSpeedX, 0, 0);

    private void Start()
    {
        scrollSpeed = new(baseScrollSpeedX, 0, 0);
    }

    private void FixedUpdate()
    {
        if (!LevelManager.moveGrid) return;
        transform.position += scrollSpeed;
    }

    private void OnDisable()
    {
        LevelManager.moveGrid = true;
    }
}
