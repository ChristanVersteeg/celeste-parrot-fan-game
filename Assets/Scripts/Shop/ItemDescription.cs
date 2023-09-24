using TMPro;
using UnityEngine;

public class ItemDescription : MonoBehaviour
{
    private TextMeshProUGUI text;

    [SerializeField] private MenuCommands.MenuOptions item;


    void Start()
    {
        text = transform.parent.GetChild(0).GetComponent<TextMeshProUGUI>();
    }

    private void SetText(string text) => this.text.text = text;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (text.text != "") return;

        switch (item)
        {
            case MenuCommands.MenuOptions.SpeedUpgrade:
                SetText("Makes the player fly faster.");
                break;
            case MenuCommands.MenuOptions.HailMary:
                SetText("When you would normally die, you now get given a second chance.");
                break;
            case MenuCommands.MenuOptions.GoldenBerry:
                SetText("Introduces golden berries into the game, these are worth more than normal berries.");
                break;
            default:
                break;
        }
    }

    private void OnTriggerExit2D(Collider2D collision) => text.text = "";
}
