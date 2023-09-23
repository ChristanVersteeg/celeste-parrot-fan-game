using System;
using UnityEngine;

public class Upgrades : MonoBehaviour
{
    private int speed, speedCost, speedMax;
    public static Action<int> onUpgrade;
    private int strawberries;

    private void Start()
    {
        strawberries = PlayerPrefs.GetInt(nameof(strawberries));
        onUpgrade(strawberries);
    }

    public void UpgradeSpeed() 
    {
        if (speedMax == 3 || strawberries < speedCost) return;

        speed -= 5;
        speedCost += 5;
        speedMax += 1;

        strawberries -= speedCost; 
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
