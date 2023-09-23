using System;
using UnityEngine;

public class Upgrades : MonoBehaviour
{
    private int speed, speedCost = 5, speedMax;
    public static Action<int, MenuCommands.MenuOptions> onUpgrade;
    public static Action<int, MenuCommands.MenuOptions> onUpgrade1;
    private int strawberries;

    private void OnEnable()
    {
        speed = PlayerPrefs.GetInt(nameof(speed));
        speedCost = PlayerPrefs.GetInt(nameof(speedCost));
        speedMax = PlayerPrefs.GetInt(nameof(speedMax));

        if (speedCost == 0)
            speedCost = 5;
        strawberries = PlayerPrefs.GetInt(nameof(strawberries));
    }

    private void Start()
    {
        onUpgrade(strawberries, MenuCommands.MenuOptions.None);
        onUpgrade1(speedCost, MenuCommands.MenuOptions.SpeedUpgrade);
    }

    public void UpgradeSpeed()
    {
        if (speedMax == 3 || strawberries < speedCost) return;

        speed -= 5;
        speedMax += 1;

        onUpgrade(strawberries -= speedCost, MenuCommands.MenuOptions.SpeedUpgrade);

        if (speedMax <= 4)
            speedCost += 5;

        onUpgrade1(speedCost, MenuCommands.MenuOptions.SpeedUpgrade);
    }

    private void OnDisable()
    {
        PlayerPrefs.SetInt(nameof(speed), speed);
        PlayerPrefs.SetInt(nameof(speedCost), speedCost);
        PlayerPrefs.SetInt(nameof(speedMax), speedMax);

        PlayerPrefs.SetInt(nameof(strawberries), strawberries);
        PlayerPrefs.Save();
    }
}
