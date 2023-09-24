using System;
using UnityEngine;

public class Upgrades : MonoBehaviour
{
    private int speed, speedCost, speedCurrentMax, speedMax = 5;
    private int hailMary, hailMaryCost, hailMaryCurrentMax, hailMaryMax = 1;
    private int goldenBerry, goldenBerryCost, goldenBerryCurrentMax, goldenBerryMax = 2;
    private int dash, dashCost, dashCurrentMax, dashMax = 5;

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

        dash = PlayerPrefs.GetInt(nameof(dash));
        dashCost = PlayerPrefs.GetInt(nameof(dashCost));
        dashCurrentMax = PlayerPrefs.GetInt(nameof(dashCurrentMax));

        if (speedCost == 0) speedCost = 5;
        if (hailMaryCost == 0) hailMaryCost = 50;
        if (goldenBerryCost == 0) goldenBerryCost = 15;
        if (dashCost == 0) dashCost = 25;

        strawberries = PlayerPrefs.GetInt(nameof(strawberries));
    }

    private void Start()
    {
        onBerryChange(strawberries);
        onUpgrade(speedCost, speedCurrentMax, speedMax, MenuCommands.MenuOptions.SpeedUpgrade);
        onUpgrade(hailMaryCost, hailMaryCurrentMax, hailMaryMax, MenuCommands.MenuOptions.HailMary);
        onUpgrade(goldenBerryCost, goldenBerryCurrentMax, goldenBerryMax, MenuCommands.MenuOptions.GoldenBerry);
        onUpgrade(dashCost, dashCurrentMax, dashMax, MenuCommands.MenuOptions.DashUpgrade);
    }

    private void UpdateBerries(int cost)
    {
        onBerryChange(strawberries -= cost);
    }

    private bool CheckAvailability(int currentMax, int max, int cost) 
    {
        return currentMax == max || strawberries < speedCost;
    }

    public void UpgradeSpeed()
    {
        if (CheckAvailability(speedCurrentMax, speedMax, speedCost)) return;

        speed -= 2;
        speedCurrentMax += 1;

        UpdateBerries(speedCost);

        speedCost += 5;

        onUpgrade(speedCost, speedCurrentMax, speedMax, MenuCommands.MenuOptions.SpeedUpgrade);
    }

    public void HailMary()
    {
        if (CheckAvailability(hailMaryCurrentMax, hailMaryMax, hailMaryCost)) return;

        hailMary = 1;
        hailMaryCurrentMax += 1;

        UpdateBerries(hailMaryCost);

        onUpgrade(hailMaryCost, hailMaryCurrentMax, hailMaryMax, MenuCommands.MenuOptions.HailMary);
    }

    public void GoldenBerry()
    {
        if (CheckAvailability(goldenBerryCurrentMax, goldenBerryMax, goldenBerryCost)) return;

        if (goldenBerryCurrentMax == goldenBerryMax) return;

        goldenBerry += 3;
        goldenBerryCurrentMax += 1;

        UpdateBerries(goldenBerryCost);

        goldenBerryCost += 10;

        onUpgrade(goldenBerryCost, goldenBerryCurrentMax, goldenBerryMax, MenuCommands.MenuOptions.GoldenBerry);
    }

    public void Dash()
    {
        if (CheckAvailability(dashCurrentMax, dashMax, dashCost)) return;

        dash += 3;
        dashCurrentMax += 1;

        UpdateBerries(dashCost);

        dashCost += 15;

        onUpgrade(dashCost, dashCurrentMax, dashMax, MenuCommands.MenuOptions.DashUpgrade);
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

        PlayerPrefs.SetInt(nameof(dash), dash); ;
        PlayerPrefs.SetInt(nameof(dashCost), dashCost);
        PlayerPrefs.SetInt(nameof(dashCurrentMax), dashCurrentMax);

        PlayerPrefs.SetInt(nameof(strawberries), strawberries);

        PlayerPrefs.Save();
    }
}
