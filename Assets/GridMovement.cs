using UnityEngine;

public class GridMovement : MonoBehaviour
{
    public static Vector3 scrollSpeed = new(-0.1f, 0, 0);

    private void FixedUpdate()
    {
        transform.position += scrollSpeed;
    }
}
