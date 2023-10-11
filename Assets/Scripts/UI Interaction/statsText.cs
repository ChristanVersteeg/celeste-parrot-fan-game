using UnityEngine;
using TMPro;
public class DisplayStats : MonoBehaviour
{
    public TextMeshProUGUI statsText; // Reference to the TextMeshPro Text for displaying stats
    int totalStrawberries, totalDeaths;

    void Start()
    {
        // Retrieve values from PlayerPrefs
        totalDeaths = PlayerPrefs.GetInt("totalDeaths", 0);
        totalStrawberries = PlayerPrefs.GetInt("totalStrawberries", 0);
    }

    private void FixedUpdate()
    {
        if ((!LevelManager.moveVertical && !LevelManager.moveHorizontal))
        {
            totalStrawberries = PlayerPrefs.GetInt("totalStrawberries", 0);

            // Create a formatted string to display the stats
            string statsString = "Stats:\nTotal Strawberries: " + totalStrawberries + "\nTotal Deaths: " + totalDeaths;

            // Update the TextMeshPro Text component with the formatted string
            statsText.text = statsString;
        }
    }
}