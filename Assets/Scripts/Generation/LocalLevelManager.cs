using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class LocalLevelManager : MonoBehaviour
{
    public enum MovementDirection
    {
        Vertical,
        Horizontal,
        NoMovement
    }

    [Header("Level Configuration")]
    public MovementDirection movementDirection;
    public bool moveHazards;
    public int levelNumber;
    public static int currentLevel;

    [Header("Level Start and End Objects")]
    public GameObject levelStartObject;
    public GameObject levelEndObject;
    public TilemapCollider2D mapCollider;

    private float leftScreenEdge, bottomScreenEdge;

    private void FixedUpdate()
    {
        // Check if the levelEndObject has reached the appropriate edge for transition.
        if (ShouldTransitionToNextLevel())
        {
            // Trigger the transition to the next level.
            FindObjectOfType<LevelManager>().TransitionToNextLevel();
        }

        // Check if the levelStartObject enters the screen to enable colliders.
        if (levelStartObject != null && IsLevelStartObjectOnScreen())
        {
            SetCollidersEnabled(true);
        }
    }

    private void Awake()
    {
        SetCollidersEnabled(false);
        currentLevel = levelNumber;
        leftScreenEdge = Camera.main.ScreenToWorldPoint(Vector3.zero).x;
        bottomScreenEdge = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0)).y;
    }

    private bool ShouldTransitionToNextLevel()
    {
        Vector3 levelEndPosition = levelEndObject.transform.position;

        if (movementDirection == MovementDirection.Horizontal && levelEndPosition.x <= leftScreenEdge && levelNumber == LevelManager.currentLevel)
        {
            SetCollidersEnabled(false);
            return true;
        }

        if (movementDirection == MovementDirection.Vertical && levelEndPosition.y <= bottomScreenEdge && levelNumber == LevelManager.currentLevel)
        {
            SetCollidersEnabled(false);
            return true;
        }

        return false;
    }

    private bool IsLevelStartObjectOnScreen()
    {
        if (levelStartObject != null)
        {
            Vector3 screenPoint = Camera.main.WorldToViewportPoint(levelStartObject.transform.position);
            return screenPoint.x >= 0 && screenPoint.x <= 1 && screenPoint.y >= 0 && screenPoint.y <= 1;
        }
        return false;
    }

    // For example, you can add a function to enable or disable colliders.
    public void SetCollidersEnabled(bool enabled)
    {
        mapCollider.enabled = enabled;
    }
}

