using UnityEngine;
using System;
using System.Collections;

public class Strawberry : MonoBehaviour
{
    public static int count;
    private new AudioSource audio;
    private Animator animator;
    private bool started;
    new string Destroy = nameof(Destroy);

    private void Start()
    {
        name = gameObject.name;
        audio = GetComponent<AudioSource>();
        animator = GetComponent<Animator>();
        audio.volume = 0.1f;
    }

    private IEnumerator HandleCollision()
    {
        if (started) yield break;

        print("here");
        count++;
        print("there");
        print(count);

        audio.Play();

        started = true;

        animator.SetBool("Destroy", true);

        GetComponent<BoxCollider2D>().enabled = false;

        yield return new WaitWhile(() => audio.isPlaying);

        Destroy(gameObject);
    }

    private void OnCollisionEnter2D() => StartCoroutine(HandleCollision());
}