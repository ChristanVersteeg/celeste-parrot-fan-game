using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Collision : MonoBehaviour
{
    public static Action onCollision;
    private bool hailMary;
    private void Start()
    {
        hailMary = PlayerPrefs.GetInt(nameof(hailMary)) != 0;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Strawberry")) return;
        if (SceneManager.GetActiveScene().buildIndex != 1 || hailMary) return;
        onCollision();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}