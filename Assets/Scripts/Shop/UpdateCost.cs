using TMPro;
using UnityEngine;

public class UpdateCost : MonoBehaviour
{
    private TextMeshProUGUI text;
    MenuCommands.MenuOptions options;

    void OnEnable()
    {
        text = GetComponent<TextMeshProUGUI>();
        Upgrades.onUpgrade += UpdateCosts;
        options = transform.parent.parent.GetChild(0).GetComponent<Type>().option;
    }

    private void UpdateCosts(int cost, int currentmax, int max, MenuCommands.MenuOptions options)
    {
        if (this.options != options) return;

        void CheckMax()
        {
            if (currentmax == max)
                text.text = "Sold out!";
            else
                 text.text = cost.ToString();
        }

        switch (options)
        {
            case MenuCommands.MenuOptions.SpeedUpgrade:
                CheckMax();
                break;
            case MenuCommands.MenuOptions.HailMary:
                CheckMax();
                break;
            case MenuCommands.MenuOptions.GoldenBerry:
                CheckMax();
                break;
            case MenuCommands.MenuOptions.None:
                print("YOU FORGOT TO ASSIGN THE TYPE YOU DIPSHIT");
                break;
            default:
                print("YOU FORGOT TO ASSIGN THE TYPE YOU DIPSHIT");
                break;
        }
    }
}
