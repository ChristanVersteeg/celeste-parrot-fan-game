using System.Collections;
using UnityEngine;

public class HailMary : MonoBehaviour
{
    private void Start()
    {
        Collision.onCollision += Hail;
    }
    private void Hail()
    {
        transform.position = new Vector3(transform.position.x - 5, transform.position.y);
        StartCoroutine(SlowdownEffect());
    }
    private IEnumerator SlowdownEffect()
    {
        Time.timeScale = 0.3f;

        // Wait for 2 seconds while the game is slowed down

        float elapsed = 0, duration = 0;

        while (elapsed < duration)
        {
            Time.timeScale = Mathf.Lerp(0.3f, 1.0f, elapsed / duration);
            elapsed += Time.unscaledDeltaTime; // Use unscaledDeltaTime to ensure smooth lerp regardless of timeScale
            yield return null;
        }

        Time.timeScale = 1.0f;
    }
}
