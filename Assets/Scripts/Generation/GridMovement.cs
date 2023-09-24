using UnityEngine;

public class GridMovement : MonoBehaviour
{
    public static Vector3 scrollSpeed = new(0, 0, 0);

    private void FixedUpdate()
    {
        if (LevelManager.moveVertical && LevelManager.moveHorizontal) scrollSpeed = new(-0.1f, 0.1f, 0);
        else if(LevelManager.moveHorizontal) scrollSpeed = new(-0.1f, 0, 0);
        else if (LevelManager.moveVertical) scrollSpeed = new(0, -0.05f, 0);

        if (!LevelManager.moveGrid) return;
        transform.position += scrollSpeed;
    }

    private void OnDisable()
    {
        LevelManager.moveGrid = true;
    }
}
