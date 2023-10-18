using UnityEngine;
using static UnityEngine.KeyCode;
using static UnityEngine.Vector3;
using UnityEngine.SceneManagement;

public class Movement : MonoBehaviour
{
    public static bool canMove = true;
    private const int baseSpeed = 25;
    private int speed = baseSpeed;
    private Vector3 direction;
    private int activeScene;
    private int dash;
    private Rigidbody2D rb;
    private float dashSpeed = -0.175f;
    GameObject dashObj;
    private bool updateDash;
    private ParticleSystem featherParticles;

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
        featherParticles = GetComponent<ParticleSystem>();
        activeScene = SceneManager.GetActiveScene().buildIndex;
        speed = (int)(activeScene != 1 ? speed / 2.5f : speed);
    }

    private void Move(KeyCode wasdKeys, KeyCode arrowKeys, Vector3 direction)
    {
        void DefaultSpeed() => this.direction += direction / speed;
        void RelativeSpeed(bool axis, float speedModifier)
        {
            if ((LevelManager.moveVertical || LevelManager.moveHorizontal) && axis) this.direction += direction / speed * speedModifier;
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
        SoundManager.speedUp = false;
        featherParticles.Stop();
        SetScrollSpeeds(GridMovement.baseScrollSpeedX, GridMovement.baseScrollSpeedY);
    }

    private void UpdateDash()
    {
        if (activeScene != 1) return;
        if (!updateDash) return;
        if (!Input.GetKeyDown(KeyCode.Space)) return;
        if (dash == 0)
        {
            dashObj.SetActive(false);
            return;
        }

        SetScrollSpeeds(dashSpeed, dashSpeed / 2);

        featherParticles.Play();
        SoundManager.speedUp = true;
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

        if (canMove)
            rb.velocity = direction * (0.75f / Time.fixedDeltaTime);

        ParticleSystem.ShapeModule shapeModule = featherParticles.shape;
        ParticleSystem.VelocityOverLifetimeModule velocityModule = featherParticles.velocityOverLifetime;

        if (LevelManager.moveHorizontal)
        {
            shapeModule.rotation = new Vector3(0.0f, -90, 0.0f);
            if (SoundManager.speedUp)
            {
                velocityModule.x = -5; velocityModule.y = 0;
            }
            else
            {
                velocityModule.x = -2.5f; velocityModule.x = 0;
            }
        }
        else if (LevelManager.moveVertical)
        {
            shapeModule.rotation = new Vector3(90.0f, 0.0f, 0.0f);
            if (SoundManager.speedUp)
            {
                velocityModule.y = -2.5f; velocityModule.x = 0;
            }
            else
            {
                velocityModule.y = -1.25f; velocityModule.x = 0;
            }
        }
    }
}
