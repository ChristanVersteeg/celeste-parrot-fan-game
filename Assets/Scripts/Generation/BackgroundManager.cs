using UnityEngine;

public class BackgroundManager : MonoBehaviour
{
    private Vector3 scrollSpeed = new(-0.01f, 0, 0);
    [SerializeField] private SpriteRenderer[] renderers;
    [SerializeField] private Sprite[] bgs;
    private int bgIndex, bgTransitionCount;
    private readonly int bgTransitionTreshold = 5;
    private const int parent = 0, child = 1;

    private void UpdateBackground()
    {
        foreach (SpriteRenderer renderer in renderers)
            renderer.sprite = bgs[bgIndex];
        renderers[child].transform.position = Vector3.zero;
        renderers[child].transform.position += new Vector3(renderers[parent].size.x, 0);
    }

    private void ChangeBackground()
    {
        bgIndex = (bgIndex + 1) % bgs.Length;
        UpdateBackground();
    }

    private void Start() => UpdateBackground();

    private void Update()
    {
        transform.position += scrollSpeed;

        if (transform.position.x * -1 >= renderers[parent].size.x)
        {
            transform.position = Vector3.zero;
            bgTransitionCount++;
        }
        else if (bgTransitionCount == bgTransitionTreshold)
        {
            ChangeBackground();
            bgTransitionCount = 0;
        }
    }
}
