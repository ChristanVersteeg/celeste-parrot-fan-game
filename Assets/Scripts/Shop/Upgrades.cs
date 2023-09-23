using System;
using UnityEngine;

public class Upgrades : MonoBehaviour
{
    private int speed, speedCost, speedCurrentMax, speedMax = 5;
    private int hailMary, hailMaryCost, hailMaryCurrentMax, hailMaryMax = 1;
    public static Action<int> onBerryChange;
    public static Action<int, int, int, MenuCommands.MenuOptions> onUpgrade;
    private int strawberries;

    private void OnEnable()
    {
        speed = PlayerPrefs.GetInt(nameof(speed));
        speedCost = PlayerPrefs.GetInt(nameof(speedCost));
        speedCurrentMax = PlayerPrefs.GetInt(nameof(speedCurrentMax));

        hailMary = PlayerPrefs.GetInt(nameof(hailMary));
        hailMaryCost = PlayerPrefs.GetInt(nameof(hailMaryCost));
        hailMaryCurrentMax = PlayerPrefs.GetInt(nameof(hailMaryCurrentMax));

        if (speedCost == 0) speedCost = 5;
        if (hailMaryCost == 0) hailMaryCost = 25;

        strawberries = PlayerPrefs.GetInt(nameof(strawberries));
    }

    private void Start()
    {
        onBerryChange(strawberries);
        onUpgrade(speedCost, speedCurrentMax, speedMax, MenuCommands.MenuOptions.SpeedUpgrade);
        onUpgrade(hailMaryCost, hailMaryCurrentMax, hailMaryMax, MenuCommands.MenuOptions.HailMary);
    }

    private void UpdateBerries(int cost)
    {
        onBerryChange(strawberries -= cost);
    }

    public void UpgradeSpeed()
    {
        if (speedCurrentMax == 5 || strawberries < speedCost) return;

        speed -= 2;
        speedCurrentMax += 1;

        UpdateBerries(speedCost);

        speedCost += 5;

        onUpgrade(speedCost, speedCurrentMax, speedMax, MenuCommands.MenuOptions.SpeedUpgrade);
    }

    public void HailMary() 
    {
        if (hailMary == 1) return;

        hailMary = 1;
        hailMaryCurrentMax += 1;

        UpdateBerries(hailMaryCost);

        onUpgrade(hailMaryCost, hailMaryCurrentMax, hailMaryMax, MenuCommands.MenuOptions.HailMary);
    }

    private void OnDisable()
    {
        PlayerPrefs.SetInt(nameof(speed), speed);
        PlayerPrefs.SetInt(nameof(speedCost), speedCost);
        PlayerPrefs.SetInt(nameof(speedCurrentMax), speedCurrentMax);

        PlayerPrefs.SetInt(nameof(hailMary), hailMary);
        PlayerPrefs.SetInt(nameof(hailMaryCost), hailMaryCost);
        PlayerPrefs.SetInt(nameof(hailMaryCurrentMax), hailMaryCurrentMax);

        PlayerPrefs.SetInt(nameof(strawberries), strawberries);

        PlayerPrefs.Save();
    }
}
