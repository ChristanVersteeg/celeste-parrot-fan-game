using UnityEngine;
using System;
using System.Collections;

public class Strawberry : MonoBehaviour
{
    public static Action onPickUp;
    private new AudioSource audio;
    private bool started;

    private void Start()
    {
        audio = GetComponent<AudioSource>();
        audio.volume = 0.1f;
    }

    private IEnumerator HandleCollision() 
    {
        if (started) yield break;
        
        onPickUp?.Invoke();

        audio.Play();

        started = true;

        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<BoxCollider2D>().enabled = false;

        yield return new WaitWhile(() => audio.isPlaying);

        Destroy(gameObject);
    }

    private void OnCollisionEnter2D() => StartCoroutine(HandleCollision());
}
