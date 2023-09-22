using UnityEngine;
using TMPro;
using System.Collections;
using UnityEngine.SceneManagement;

public class ColorTransition : MonoBehaviour
{
    private TMP_Text text;
    private int currentCharIndex = 0;
    private float colorChangeDelay = 0.25f; // Delay between each character color change
    private float nextColorChangeTime;
    private Coroutine transitionCoroutine;
    private bool collisionState, nextSceneLoading;

    private IEnumerator RunTransition()
    {
        yield return new WaitForSeconds(colorChangeDelay * text.textInfo.characterCount);
        nextSceneLoading = true;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    private IEnumerator ResetColor()
    {
        var textInfo = text.textInfo;

        for (int i = currentCharIndex - 1; i >= 0; --i)
        {
            var charInfo = textInfo.characterInfo[i];
            var vertexColors = textInfo.meshInfo[charInfo.materialReferenceIndex].colors32;

            for (int j = 0; j < 4; ++j)
            {
                vertexColors[charInfo.vertexIndex + j] = Color.white;
            }

            text.UpdateVertexData(TMP_VertexDataUpdateFlags.Colors32); // Update the vertex colors to reflect the change to white
            yield return new WaitForSeconds(colorChangeDelay / 2);
        }

        // Reset the index to start coloring characters from the beginning next time.
        currentCharIndex = 0;
    }




    private void Start()
    {
        text = GetComponent<TMP_Text>();
    }

    private void OnCollisionEnter2D()
    {
        collisionState = true;

        transitionCoroutine = StartCoroutine(RunTransition());
    }

    private void OnCollisionExit2D()
    {
        collisionState = false;

        StopCoroutine(transitionCoroutine);
        transitionCoroutine = null;

        if (!nextSceneLoading)
            StartCoroutine(ResetColor());
    }

    void Update()
    {
        if (!collisionState) return;

        var textInfo = text.textInfo;

        if (Time.time > nextColorChangeTime && currentCharIndex < textInfo.characterCount)
        {
            text.ForceMeshUpdate(); // Force update the mesh to reflect changes

            var charInfo = textInfo.characterInfo[currentCharIndex];
            var vertexColors = textInfo.meshInfo[charInfo.materialReferenceIndex].colors32;

            for (int j = 0; j < 4; ++j)
            {
                vertexColors[charInfo.vertexIndex + j] = Color.green;
            }

            currentCharIndex++;
            nextColorChangeTime = Time.time + colorChangeDelay;
            text.UpdateVertexData(TMP_VertexDataUpdateFlags.Colors32); // Update the vertex colors
        }

        // Make sure that all previous characters remain green
        for (int i = 0; i < currentCharIndex; ++i)
        {
            var charInfo = textInfo.characterInfo[i];
            var vertexColors = textInfo.meshInfo[charInfo.materialReferenceIndex].colors32;

            for (int j = 0; j < 4; ++j)
            {
                vertexColors[charInfo.vertexIndex + j] = Color.green;
            }
        }

        if (currentCharIndex > 0)
        {
            text.UpdateVertexData(TMP_VertexDataUpdateFlags.Colors32); // Update the vertex colors
        }
    }
}
