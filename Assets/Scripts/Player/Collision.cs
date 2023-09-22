using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Collision : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (SceneManager.GetActiveScene().buildIndex != 1) return;

        if(collision.gameObject.name != Strawberry.name)
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
