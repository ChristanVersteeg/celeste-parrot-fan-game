using UnityEngine;
using System;

public class Strawberry : MonoBehaviour
{
    public static Action onPickUp;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        onPickUp?.Invoke();
        Destroy(gameObject);
    }
}
