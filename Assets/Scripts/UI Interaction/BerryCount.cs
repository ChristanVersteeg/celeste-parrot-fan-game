using TMPro;
using UnityEngine;

public class BerryCount : MonoBehaviour
{
    private TextMeshProUGUI text;

    private void OnEnable()
    {
        text.GetComponent<TextMeshProUGUI>();
        Upgrades.onUpgrade += UpdateText;
    }

    private void UpdateText(int count)
    {
        text.text = $"X {count}";
    }
}