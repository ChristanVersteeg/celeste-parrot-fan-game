using UnityEngine;
using System.Collections;

public class Strawberry : MonoBehaviour
{
    public static int count;
    [HideInInspector] public int incrementor = 1;
    public new AudioClip audio;
    private Animator animator;
    private bool started;
    new string Destroy = nameof(Destroy);

    protected virtual void Start()
    {
        name = gameObject.name;
        animator = GetComponent<Animator>();
    }

    private IEnumerator HandleCollision()
    {
        if (started) yield break;

        count += incrementor;
        PlayerPrefs.SetInt("totalStrawberries", PlayerPrefs.GetInt("totalStrawberries") + incrementor);
        SoundManager.PlayOneShot(audio);

        started = true;


        animator.SetBool("Destroy", true);

        GetComponent<BoxCollider2D>().enabled = false;

        yield return new WaitWhile(() => SoundManager.oneshotPlayer.isPlaying);
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D() => StartCoroutine(HandleCollision());
}