using UnityEngine;
using static UnityEngine.KeyCode;
using static UnityEngine.Vector3;
using UnityEngine.SceneManagement;

public class Movement : MonoBehaviour
{
    private int speed = 25;
    private Vector3 direction;

    private void Start() => speed = (int)(SceneManager.GetActiveScene().buildIndex != 1 ? speed / 2.5f : speed);

    private void Move(KeyCode key, Vector3 direction)
    {
        if (Input.GetKey(key))
            this.direction += direction == left ? direction / speed * 2.5f : direction / speed;
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
