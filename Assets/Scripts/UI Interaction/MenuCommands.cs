using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuCommands : MonoBehaviour
{
    public static bool nextSceneLoading;
    [SerializeField] private GameObject credits;

    public enum MenuOptions 
    {
        Play,
        Settings,
        Credits,
        Exit,
        Back
    }

    public void RunOption(MenuOptions options) 
    {
        switch (options)
        {
            case MenuOptions.Play:
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
                nextSceneLoading = true;
                break;
            case MenuOptions.Settings:
                break;
            case MenuOptions.Credits:
                credits.SetActive(true);
                break;
            case MenuOptions.Exit:
                break;
            case MenuOptions.Back:
                credits.SetActive(false);
                break;
            default:
                break;
        }
    }
}
