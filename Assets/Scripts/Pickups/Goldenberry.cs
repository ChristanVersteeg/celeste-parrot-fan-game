using UnityEngine;

public class Goldenberry : Strawberry
{
    private void OnEnable()
    {
        gameObject.SetActive(PlayerPrefs.GetInt("goldenBerry") != 0);
    }

    protected override void Start()
    {
        incrementor = 5;
        base.Start();
    }
}