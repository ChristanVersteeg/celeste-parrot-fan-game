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

    public void SetMovementType(LocalLevelManager.MovementDirection movementType)
    {
        Debug.Log(movementType);
        switch (movementType)
        {
            case LocalLevelManager.MovementDirection.Horizontal:
                scrollSpeed = new Vector3(baseScrollSpeedX, 0, 0);
                break;
            case LocalLevelManager.MovementDirection.Vertical:
                scrollSpeed = new Vector3(0, baseScrollSpeedY, 0);
                break;
            case LocalLevelManager.MovementDirection.NoMovement:
                scrollSpeed = Vector3.zero;
                break;
        }
    }

    private void FixedUpdate()
    {
        // Move the grid based on the adjusted scrollSpeed.
        transform.position += scrollSpeed;
    }
}
