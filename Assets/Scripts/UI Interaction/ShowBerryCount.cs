using TMPro;
using UnityEngine;

public class ShowBerryCount : MonoBehaviour
{
    private TextMeshProUGUI text;
    private int totalStrawberries;

    void Start()
    {
        totalStrawberries = Strawberry.count + PlayerPrefs.GetInt("StrawberryCount", totalStrawberries);
        text = GetComponent<TextMeshProUGUI>();
        text.text = $"X {totalStrawberries}";
    }

    private void OnDisable()
    {
        PlayerPrefs.SetInt("StrawberryCount", totalStrawberries);
        PlayerPrefs.Save();
        Strawberry.count = 0;
    }

    void Update()
    {
        
    }
}
