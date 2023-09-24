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
    private int dash;
    private Rigidbody2D rb;
    private float dashSpeed = -0.175f;
    GameObject dashObj;
    private bool updateDash;

    private void StartUpdatingDash() => updateDash = true;

    private void Start()
    {
        Invoke(nameof(StartUpdatingDash), 0.5f);
        speed = baseSpeed;
        speed += PlayerPrefs.GetInt(nameof(speed));
        dash = PlayerPrefs.GetInt(nameof(dash));
        dashObj = transform.GetChild(1).gameObject;
        dashObj.SetActive(dash != 0);
        rb = GetComponent<Rigidbody2D>();
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

    private void SetScrollSpeeds(float speedX, float speedY)
    {
        if (LevelManager.moveHorizontal)
        {
            GridMovement.scrollSpeed = new Vector3(speedX, 0);
        }
        else if (LevelManager.moveVertical)
        {
            GridMovement.scrollSpeed = new Vector3(0, speedY);
        }
    }

    private void ResetDashSpeed()
    {
        SetScrollSpeeds(GridMovement.baseScrollSpeedX, GridMovement.baseScrollSpeedY);
    }

    private void UpdateDash()
    {
        if (activeScene != 1) return;
        if(!updateDash) return;
        if (!Input.GetKeyDown(KeyCode.Space)) return;
        if (dash == 0) 
        {
            dashObj.SetActive(false);
            return;
        }

        SetScrollSpeeds(dashSpeed, dashSpeed / 2);
        
        dash--;

        Invoke(nameof(ResetDashSpeed), 3);
    }

    private void Update()
    {
        UpdateDash();
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

        rb.velocity = direction * (0.75f / Time.fixedDeltaTime); //60 is FPS estimate //That's a terrible estimate
    }
}
