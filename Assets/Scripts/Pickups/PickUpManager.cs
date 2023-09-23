using UnityEngine;

public class PickUpManager : MonoBehaviour
{
    private void OnDisable()
    {
        PlayerPrefs.SetInt("StrawberryCount", Strawberry.count + PlayerPrefs.GetInt("StrawberryCount"));
        PlayerPrefs.Save();
        Strawberry.count = 0;
    }
}
