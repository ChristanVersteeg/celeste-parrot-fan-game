using UnityEngine;

public class PickUpManager : MonoBehaviour
{
    private void OnDisable()
    {
        PlayerPrefs.SetInt("strawberries", Strawberry.count + PlayerPrefs.GetInt("strawberries"));
        PlayerPrefs.SetInt("totalStrawberries", Strawberry.count + PlayerPrefs.GetInt("totalStrawberries"));
        PlayerPrefs.Save();
        Strawberry.count = 0;
    }
}
