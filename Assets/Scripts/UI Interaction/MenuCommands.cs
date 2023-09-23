using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuCommands : MonoBehaviour
{
    public static bool nextSceneLoading;
    [SerializeField] private GameObject credits;
    private Upgrades upgrades;

    private void Start()
    {
        upgrades = GetComponent<Upgrades>();
        Time.timeScale = 1.0f; 
    }

    public enum MenuOptions 
    { 
        Play,
        Settings,
        Credits,
        Exit,
        Back,

        None,

        SpeedUpgrade,
        HailMary
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
            case MenuOptions.SpeedUpgrade:
                upgrades.UpgradeSpeed();
                break;
            case MenuOptions.HailMary:
                upgrades.HailMary();
                break;
            default:
                break;
        }
    }
}
