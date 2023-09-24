using UnityEngine;
using static UnityEngine.KeyCode;
using static UnityEngine.Vector3;
using UnityEngine.SceneManagement;

public class Movement : MonoBehaviour
{
    private const int baseSpeed = 25;
    private int speed = baseSpeed;
    private Vector3 direction;
    private int activeScene;
    [SerializeField] private Rigidbody2D rb;

    private void OnValidate()
    {
        if (rb == null)
            rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        speed = baseSpeed;
        speed += PlayerPrefs.GetInt(nameof(speed));

        activeScene = SceneManager.GetActiveScene().buildIndex;
        speed = (int)(activeScene != 1 ? speed / 2.5f : speed);
    }

    private void Move(KeyCode wasdKeys, KeyCode arrowKeys, Vector3 direction)
    {
        void DefaultSpeed() => this.direction += direction / speed;
        void RelativeSpeed(bool axis, float speedModifier)
        {
            if (LevelManager.moveGrid && axis) this.direction += direction / speed * speedModifier;
            else DefaultSpeed();
        }

        if (Input.GetKey(wasdKeys) || Input.GetKey(arrowKeys))
        {
            if (activeScene != 1)
            {
                DefaultSpeed();

                return;
            }

            if (direction != left)
                DefaultSpeed();
            else
            {
                RelativeSpeed(LevelManager.moveHorizontal, 2.5f);
            }

            if (direction != down)
                DefaultSpeed();
            else
                RelativeSpeed(LevelManager.moveVertical, 1.75f);
        }
    }

    void FixedUpdate()
    {
        direction = zero;

        Move(W, UpArrow, up);
        Move(A, LeftArrow, left);
        Move(S, DownArrow, down);
        Move(D, RightArrow, right);

        if (direction.magnitude > 1)
            direction.Normalize();

        rb.velocity = direction * 60; //60 is FPS estimate
    }
}
