using System.Collections;
using UnityEngine;

public class HailMary : MonoBehaviour
{
    private Collision collision;
    private Rigidbody2D rb;
    private bool hailed;
    private Vector2 hailMarySpeedX = new(-25f, 0), hailMarySpeedY = new(0, -12.5f);

    private void OnEnable()
    {
        Collision.onCollision += Hail;
        collision = GetComponent<Collision>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void EnableMovement()
    {
        Movement.canMove = true;
        StartCoroutine(SlowdownEffect());
    }

    private void Hail()
    {
        if (!collision.hailMary) return;
        if (hailed) return;
        Movement.canMove = false;
        Invoke(nameof(EnableMovement), 0.25f);
        rb.AddForce(LevelManager.moveHorizontal ? hailMarySpeedX : hailMarySpeedY, ForceMode2D.Impulse);
        hailed = true;
    }

    private IEnumerator SlowdownEffect()
    {
        Time.timeScale = 0.3f;

        float elapsed = 0, duration = 2;

        while (elapsed < duration)
        {
            Time.timeScale = Mathf.Lerp(0.5f, 1.0f, elapsed / duration);
            elapsed += Time.unscaledDeltaTime; // Use unscaledDeltaTime to ensure smooth lerp regardless of timeScale
            yield return null;
        }

        Time.timeScale = 1.0f;
        collision.hailMary = false;
    }

    private void OnDisable()
    {
        Collision.onCollision -= Hail;
    }
}