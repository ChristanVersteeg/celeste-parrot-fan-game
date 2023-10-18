using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField] private AudioClip[] audioClips;
    public AudioSource audioSource;
    private int currentClipIndex = 0;
    public static bool speedUp = false;

    private void Start()
    {
        // Set up the first audio clip to play
        PlayAudioClip(currentClipIndex);
    }

    private void FixedUpdate()
    {
        if (!audioSource.isPlaying && currentClipIndex == 0) //switch from starting script to next
        {
            // Switch to the next audio clip
            SwitchToNextClip();
        }
        else if (!audioSource.isPlaying)  // Check if the current audio clip has finished playing
        {
            // Loop the currently playing audio clip
            LoopCurrentClip();
        }

        if (speedUp && LevelManager.moveHorizontal)
        {
            audioSource.pitch = 1.75f;
        }
        else if (speedUp && LevelManager.moveVertical)
        {
            audioSource.pitch = 1;
        }
        else if (LevelManager.moveHorizontal)
        {
            audioSource.pitch = 1;
        }
        else if (LevelManager.moveVertical)
        {
            audioSource.pitch = 0.875f;
        }
        else
        {
            audioSource.pitch = 1;
        }
    }

    private void PlayAudioClip(int index)
    {
        if (index >= 0 && index < audioClips.Length)
        {
            audioSource.clip = audioClips[index];
            audioSource.loop = false; // Ensure looping is off initially
            audioSource.Play();
        }
    }

    private void LoopCurrentClip()
    {
        if (audioSource.clip != null)
        {
            audioSource.loop = true;
            audioSource.Play();
        }
    }

    private void SwitchToNextClip()
    {
        currentClipIndex = (currentClipIndex + 1) % audioClips.Length;
        PlayAudioClip(currentClipIndex);
    }
}