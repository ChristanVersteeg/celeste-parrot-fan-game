using System;
using UnityEngine;

public class Upgrades : MonoBehaviour
{
    private int speed, speedCost, speedCurrentMax, speedMax = 5;
    public static Action<int> onBerryChange;
    public static Action<int, int, int, MenuCommands.MenuOptions> onUpgrade;
    private int strawberries;

    private void OnEnable()
    {
        speed = PlayerPrefs.GetInt(nameof(speed));
        speedCost = PlayerPrefs.GetInt(nameof(speedCost));
        speedCurrentMax = PlayerPrefs.GetInt(nameof(speedCurrentMax));

        if (speedCost == 0) speedCost = 5;

        strawberries = PlayerPrefs.GetInt(nameof(strawberries));
    }

    private void Start()
    {
        onBerryChange(strawberries);
        onUpgrade(speedCost, speedCurrentMax, speedMax, MenuCommands.MenuOptions.SpeedUpgrade);
    }

    public void UpgradeSpeed()
    {
        if (speedCurrentMax == 5 || strawberries < speedCost) return;

        speed -= 2;
        speedCurrentMax += 1;

        onBerryChange(strawberries -= speedCost);

        speedCost += 5;

        onUpgrade(speedCost, speedCurrentMax, speedMax, MenuCommands.MenuOptions.SpeedUpgrade);
    }

    private void OnDisable()
    {
        PlayerPrefs.SetInt(nameof(speed), speed);
        PlayerPrefs.SetInt(nameof(speedCost), speedCost);
        PlayerPrefs.SetInt(nameof(speedCurrentMax), speedCurrentMax);

        PlayerPrefs.SetInt(nameof(strawberries), strawberries);
        PlayerPrefs.Save();
    }
}
