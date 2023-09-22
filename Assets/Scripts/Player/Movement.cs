using UnityEngine;
using static UnityEngine.KeyCode;
using static UnityEngine.Vector3;
using UnityEngine.SceneManagement;

public class Movement : MonoBehaviour
{
    private int speed = 25;
    private Vector3 direction;
    private int activeScene;

    private void Start()
    {
        activeScene = (SceneManager.GetActiveScene().buildIndex);
        speed = (int)(activeScene  != 1 ? speed / 2.5f : speed);
    }

    private void Move(KeyCode key, Vector3 direction)
    {
        if (Input.GetKey(key))
            if (SceneManager.GetActiveScene().buildIndex != 1 || direction != left)
                this.direction += direction / speed;
            else
                this.direction += direction / speed * 2.5f;
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
