using UnityEngine;
using static UnityEngine.KeyCode;
using static UnityEngine.Vector3;

public class Movement : MonoBehaviour
{
    public int speed = 10;
    private Vector3 direction;

    private void Move(KeyCode key, Vector3 direction)
    {
        if (Input.GetKey(key))
            this.direction += direction / speed;
    }

    void FixedUpdate()
    {
        direction = zero;

        Move(W, up);
        Move(A, left);
        Move(S, down);
        Move(D, right);

        if (direction.magnitude > 1)
            direction.Normalize();

        transform.position += direction;
    }
}
