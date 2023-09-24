using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuCommands : MonoBehaviour
{
    public static bool nextSceneLoading;
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
        HailMary,
        GoldenBerry
    }

    private void ShowCredits(bool show)
    {
        T[] ComponentsOfType<T>() => transform.GetChild(4).GetComponentsInChildren<T>();
        foreach (Image image in ComponentsOfType<Image>())
            image.enabled = show;
        foreach (TextMeshProUGUI text in ComponentsOfType<TextMeshProUGUI>())
            text.enabled = show;
        ComponentsOfType<BoxCollider2D>()[0].enabled = show;

        for (int i = 0; i < 3; i++)
            transform.GetChild(i).GetChild(0).GetComponent<BoxCollider2D>().enabled = !show;
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
                ShowCredits(true);
                break;
            case MenuOptions.Exit:
                Application.Quit();
                break;
            case MenuOptions.Back:
                ShowCredits(false);
                break;
            case MenuOptions.SpeedUpgrade:
                upgrades.UpgradeSpeed();
                break;
            case MenuOptions.HailMary:
                upgrades.HailMary();
                break;
            case MenuOptions.GoldenBerry:
                upgrades.GoldenBerry();
                break;
            default:
                break;
        }
    }
}
