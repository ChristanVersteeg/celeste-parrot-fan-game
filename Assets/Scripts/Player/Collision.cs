using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Collision : MonoBehaviour
{
    public static Action onCollision;

    public bool hailMary;
    private GameObject hailMaryObj;

    private void Start()
    {
        hailMary = PlayerPrefs.GetInt("hailMary") != 0;
        hailMaryObj = transform.GetChild(0).gameObject;
        hailMaryObj.SetActive(hailMary);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Strawberry")) return;
        if (SceneManager.GetActiveScene().buildIndex != 1) return;
        onCollision();

        hailMaryObj.SetActive(false);
        if (hailMary) return;
        PlayerPrefs.SetInt("totalDeaths", Strawberry.count + PlayerPrefs.GetInt("totalDeaths"));
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}