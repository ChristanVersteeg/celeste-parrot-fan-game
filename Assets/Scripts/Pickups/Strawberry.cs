using UnityEngine;
using System.Collections;

public class Strawberry : MonoBehaviour
{
    public static int count;
    [HideInInspector] public int incrementor = 1;
    private new AudioSource audio;
    private Animator animator;
    private bool started;
    new string Destroy = nameof(Destroy);

    protected virtual void Start()
    {
        name = gameObject.name;
        audio = GetComponent<AudioSource>();
        animator = GetComponent<Animator>();
        audio.volume = 0.1f;
    }

    private IEnumerator HandleCollision()
    {
        if (started) yield break;

        count += incrementor;
        PlayerPrefs.SetInt("totalStrawberries", PlayerPrefs.GetInt("totalStrawberries") + incrementor);
        audio.Play();

        started = true;

        animator.SetBool("Destroy", true);

        GetComponent<BoxCollider2D>().enabled = false;

        yield return new WaitWhile(() => audio.isPlaying);
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D() => StartCoroutine(HandleCollision());
}