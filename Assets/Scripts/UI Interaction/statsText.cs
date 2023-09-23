using UnityEngine;
using TMPro;
public class DisplayStats : MonoBehaviour
{
    public TextMeshProUGUI statsText; // Reference to the TextMeshPro Text for displaying stats

    void Start()
    {
        // Retrieve values from PlayerPrefs
        int totalDeaths = PlayerPrefs.GetInt("totalDeaths", 0);
        int totalStrawberries = PlayerPrefs.GetInt("totalStrawberries", 0);

        // Create a formatted string to display the stats
        string statsString = "Stats:\nTotal Strawberries: " + totalStrawberries + "\nTotal Deaths: " + totalDeaths;

        // Update the TextMeshPro Text component with the formatted string
        statsText.text = statsString;
    }
}