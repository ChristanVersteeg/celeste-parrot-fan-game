using System;
using TMPro;
using UnityEngine;

public class SpeedrunTimer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI currentTime, overallTime;
    private float time;

    private void OnEnable()
    {
        time = PlayerPrefs.GetFloat(nameof(time));
    }

    private void OnDisable()
    {
        PlayerPrefs.SetFloat(nameof(time), time + Time.timeSinceLevelLoad);
    }

    void Update()
    {
        TimeSpan currentTimeSpan = TimeSpan.FromSeconds(time + Time.timeSinceLevelLoad);
        string currentTimeText = $"{currentTimeSpan.Hours}:{currentTimeSpan.Minutes:00}:{currentTimeSpan.Seconds:00}<size=80%><color=#808080>.{currentTimeSpan.Milliseconds:000}</color></size>";
        currentTime.text = currentTimeText;

        TimeSpan overallTimeSpan = TimeSpan.FromSeconds(Time.timeSinceLevelLoad);
        string overallTimeText = $"{overallTimeSpan.Minutes:00}:{overallTimeSpan.Seconds:00}";
        overallTime.text = overallTimeText;
    }
}
