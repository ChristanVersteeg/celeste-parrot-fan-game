using TMPro;
using UnityEngine;

public class UpdateCost : MonoBehaviour
{
    private TextMeshProUGUI text;

    void OnEnable()
    {
        text = GetComponent<TextMeshProUGUI>();
        Upgrades.onUpgrade += UpdateCosts;
    }

    private void UpdateCosts(int cost, int currentmax, int max, MenuCommands.MenuOptions options)
    {
        switch (options)
        {
            case MenuCommands.MenuOptions.SpeedUpgrade:

                if (currentmax == max)
                    text.text = "Sold out!";
                else
                    text.text = cost.ToString();

                break;
        }
    }
}
