using UnityEngine;

public class Goldenberry : Strawberry
{
    private int goldenBerry;

    private void OnEnable()
    {
        goldenBerry = PlayerPrefs.GetInt("goldenBerry");
        gameObject.SetActive(goldenBerry != 0);
    }

    protected override void Start()
    {
        incrementor = goldenBerry;
        base.Start();
    }
}