using System.Collections;
using UnityEngine;

public class HailMary : MonoBehaviour
{
    private Collision collision;
    private void OnEnable()
    {
        Collision.onCollision += Hail;
        collision = GetComponent<Collision>();
    }

    private void Hail()
    {
        if (!collision.hailMary) return;

        transform.position = new Vector3(transform.position.x - 2.5f, transform.position.y);
        StartCoroutine(SlowdownEffect());
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
