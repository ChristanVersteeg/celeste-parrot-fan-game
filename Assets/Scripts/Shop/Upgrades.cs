using System;
using UnityEngine;

public class Upgrades : MonoBehaviour
{
    private int speed, speedCost, speedCurrentMax, speedMax = 5;
    private int hailMary, hailMaryCost, hailMaryCurrentMax, hailMaryMax = 1;
    private int goldenBerry, goldenBerryCost, goldenBerryCurrentMax, goldenBerryMax = 2;

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

        goldenBerry = PlayerPrefs.GetInt(nameof(goldenBerry));
        goldenBerryCost = PlayerPrefs.GetInt(nameof(goldenBerryCost));
        goldenBerryCurrentMax = PlayerPrefs.GetInt(nameof(goldenBerryCurrentMax));

        if (speedCost == 0) speedCost = 5;
        if (hailMaryCost == 0) hailMaryCost = 50;
        if (goldenBerryCost == 0) goldenBerryCost = 15;

        strawberries = PlayerPrefs.GetInt(nameof(strawberries));
    }

    private void Start()
    {
        onBerryChange(strawberries);
        onUpgrade(speedCost, speedCurrentMax, speedMax, MenuCommands.MenuOptions.SpeedUpgrade);
        onUpgrade(hailMaryCost, hailMaryCurrentMax, hailMaryMax, MenuCommands.MenuOptions.HailMary);
        onUpgrade(goldenBerryCost, goldenBerryCurrentMax, goldenBerryMax, MenuCommands.MenuOptions.GoldenBerry);
    }

    private void UpdateBerries(int cost)
    {
        onBerryChange(strawberries -= cost);
    }

    public void UpgradeSpeed()
    {
        if (speedCurrentMax == speedMax || strawberries < speedCost) return;

        speed -= 2;
        speedCurrentMax += 1;

        UpdateBerries(speedCost);

        speedCost += 5;

        onUpgrade(speedCost, speedCurrentMax, speedMax, MenuCommands.MenuOptions.SpeedUpgrade);
    }

    public void HailMary()
    {
        if (hailMaryCurrentMax == hailMaryMax) return;

        hailMary = 1;
        hailMaryCurrentMax += 1;

        UpdateBerries(hailMaryCost);

        onUpgrade(hailMaryCost, hailMaryCurrentMax, hailMaryMax, MenuCommands.MenuOptions.HailMary);
    }

    public void GoldenBerry()
    {
        if (goldenBerryCurrentMax == goldenBerryMax) return;

        goldenBerry += 3;
        goldenBerryCurrentMax += 1;

        UpdateBerries(goldenBerryCost);

        goldenBerryCost += 20;

        onUpgrade(goldenBerryCost, goldenBerryCurrentMax, goldenBerryMax, MenuCommands.MenuOptions.GoldenBerry);
    }

    private void OnDisable()
    {
        PlayerPrefs.SetInt(nameof(speed), speed);
        PlayerPrefs.SetInt(nameof(speedCost), speedCost);
        PlayerPrefs.SetInt(nameof(speedCurrentMax), speedCurrentMax);

        PlayerPrefs.SetInt(nameof(hailMary), hailMary);
        PlayerPrefs.SetInt(nameof(hailMaryCost), hailMaryCost);
        PlayerPrefs.SetInt(nameof(hailMaryCurrentMax), hailMaryCurrentMax);

        PlayerPrefs.SetInt(nameof(goldenBerry), goldenBerry);;
        PlayerPrefs.SetInt(nameof(goldenBerryCost), goldenBerryCost);
        PlayerPrefs.SetInt(nameof(goldenBerryCurrentMax), goldenBerryCurrentMax);

        PlayerPrefs.SetInt(nameof(strawberries), strawberries);

        PlayerPrefs.Save();
    }
}
