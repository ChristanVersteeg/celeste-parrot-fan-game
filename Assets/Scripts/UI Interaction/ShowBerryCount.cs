using TMPro;
using UnityEngine;

public class ShowBerryCount : MonoBehaviour
{
    private TextMeshProUGUI text;
    private int strawberries;

    void Start()
    {
        strawberries = PlayerPrefs.GetInt("StrawberryCount");
        text = GetComponent<TextMeshProUGUI>();
        text.text = $"X {strawberries}";
    }

    private void OnDisable()
    {
        PlayerPrefs.SetInt("StrawberryCount", strawberries);
        PlayerPrefs.Save();
    }

    void Update()
    {
        
    }
}
