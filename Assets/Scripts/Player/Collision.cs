using UnityEngine;
using UnityEngine.SceneManagement;

public class Collision : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Strawberry")) return;
        if (SceneManager.GetActiveScene().buildIndex != 1) return;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}