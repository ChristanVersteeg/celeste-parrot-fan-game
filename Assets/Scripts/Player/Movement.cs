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
    private new SpriteRenderer renderer;
    private Transform haloPos;

    private void Start()
    {
        speed = baseSpeed;
        speed += PlayerPrefs.GetInt(nameof(speed));

        renderer = GetComponent<SpriteRenderer>();
        haloPos = transform.GetChild(0).GetComponent<Transform>();
        activeScene = (SceneManager.GetActiveScene().buildIndex);
        speed = (int)(activeScene != 1 ? speed / 2.5f : speed);
    }

    private void Move(KeyCode key, Vector3 direction, bool flipX = false)
    {
        if (Input.GetKey(key))
        {
            if (SceneManager.GetActiveScene().buildIndex != 1)
            {
                this.direction += direction / speed;

                return;
            }

            if (direction != left)
            {
                this.direction += direction / speed;
            }
            else
            {
                if (LevelManager.moveGrid && LevelManager.moveHorizontal) this.direction += direction / speed * 2.5f;
                else this.direction += direction / speed;
            }

            if (direction != down)
            {
                this.direction += direction / speed;
            }
            else
            {
                if (LevelManager.moveGrid && LevelManager.moveVertical) this.direction += direction / speed * 1.75f;
                else this.direction += direction / speed;
            }

            //renderer.flipX = flipX;
            //haloPos.localPosition = new Vector3(flipX ? -haloPos.localPosition.x : Mathf.Abs(haloPos.localPosition.x), haloPos.localPosition.y);
        }
    }

    void FixedUpdate()
    {
        direction = zero;

        Move(W, up);
        Move(A, left, true);
        Move(S, down);
        Move(D, right);

        if (direction.magnitude > 1)
            direction.Normalize();

        transform.position += direction;
    }
}
