using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Collision : MonoBehaviour
{
    public static Action onCollision;

    public bool hailMary;

    private void Start()
    {
        hailMary = PlayerPrefs.GetInt("hailMary") != 0;
        transform.GetChild(0).gameObject.SetActive(hailMary);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Strawberry")) return;
        if (SceneManager.GetActiveScene().buildIndex != 1) return;
        onCollision();

        if (hailMary) return;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}