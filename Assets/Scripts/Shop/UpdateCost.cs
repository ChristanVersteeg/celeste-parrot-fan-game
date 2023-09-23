using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.U2D.IK;

public class UpdateCost : MonoBehaviour
{
    private TextMeshProUGUI text;
    private MenuCommands.MenuOptions options;
    void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
        options = GetComponent<Type>().option;
        Upgrades.onUpgrade1 += UpdateCostaRica;
    }

    private void UpdateCostaRica(int cost, MenuCommands.MenuOptions options)
    {
        if (this.options != options) return;

        if (cost != 15)
            text.text = $"Speed {cost} X";
        else 
            text.text = $"Sold out!";
    }
}
