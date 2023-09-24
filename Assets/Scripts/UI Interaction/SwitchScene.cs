using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchScene : MonoBehaviour
{
    private int activeScene;

    private void Start()
    {
        activeScene = SceneManager.GetActiveScene().buildIndex;
    }

    private void SwitchIfKeyPress(KeyCode key, int scene) 
    {
        if (Input.GetKeyDown(key))
            SceneManager.LoadScene(activeScene - scene);
    }

    private void Update()
    {
        SwitchIfKeyPress(KeyCode.Space, 1);
        SwitchIfKeyPress(KeyCode.Return, 2);
    }
}
