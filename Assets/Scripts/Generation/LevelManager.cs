using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Tilemaps;

public class LevelManager : MonoBehaviour
{
    private LocalLevelManager[] levelManagers; // An array of all LocalLevelManagers.
    public static int currentLevel;
    private GridMovement gridMovement; // Reference to the GridMovement component.

    public static bool moveHazards; // Boolean to notate if hazards should move.
    public static bool moveHorizontal; // Boolean to notate if the current movement is horizontal.
    public static bool moveVertical; // Boolean to notate if the current movement is vertical.

    void Start()
    {
        // Find all LocalLevelManagers in the scene.
        levelManagers = FindObjectsOfType<LocalLevelManager>();

        // Sort the levelManagers array based on currentLevel.
        Array.Sort(levelManagers, (lm1, lm2) => lm1.levelNumber.CompareTo(lm2.levelNumber));

        // Get the GridMovement component from the GameObject.
        gridMovement = GetComponent<GridMovement>();
        if (gridMovement == null)
        {
            Debug.LogError("GridMovement component not found.");
        }

        // Initialize the first level.
        ActivateLevel(levelManagers[0].levelNumber);
    }

    private void ActivateLevel(int levelIndex)
    {
        // Activate the new level.
        if (levelIndex >= 0 && levelIndex < levelManagers.Length)
        {
            Debug.Log(levelManagers[levelIndex]);
            currentLevel = levelIndex;

            // Update the moveHazards boolean based on the active level.
            moveHazards = levelManagers[levelIndex].moveHazards;

            // Set the movement type for the GridMovement based on the active level.
            gridMovement.SetMovementType(levelManagers[levelIndex].movementDirection);
            if (levelManagers[levelIndex].movementDirection == LocalLevelManager.MovementDirection.Vertical) { moveVertical = true; } else { moveVertical = false; }
            if (levelManagers[levelIndex].movementDirection == LocalLevelManager.MovementDirection.Horizontal) { moveHorizontal = true; } else { moveHorizontal = false; }

            // Print the information you requested.
            Debug.Log("Level Index: " + levelIndex);
            Debug.Log("Movement Direction: " + levelManagers[levelIndex].movementDirection);
        }
    }

    public void TransitionToNextLevel()
    {
        // Transition to the next level.
        int nextLevelIndex = Array.IndexOf(levelManagers, levelManagers.FirstOrDefault(lm => lm.levelNumber == levelManagers[currentLevel].levelNumber)) + 1;
        ActivateLevel(nextLevelIndex);
    }
}

