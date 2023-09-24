using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BladeCollision : MonoBehaviour
{
    public int inLevel;
    private enum MovementState
    {
        Vertical,
        Horizontal,
        None
    }
    public float movementSpeed = 0.1f;
    [SerializeField] private MovementState movementState = MovementState.None;

    private void FixedUpdate()
    {
        if (!LevelManager.moveHazards) return;

        Vector3 movement = Vector3.zero;

        switch (movementState)
        {
            case MovementState.Vertical:
                if (inLevel != LevelManager.currentLevel) return;
                movement = new Vector3(0, movementSpeed, 0);
                break;
            case MovementState.Horizontal:
                if (inLevel != LevelManager.currentLevel) return;
                if (movementSpeed > 0) movement = new Vector3(movementSpeed, 0, 0);
                if (movementSpeed < 0) movement = new Vector3(movementSpeed, 0, 0);
                break;
            case MovementState.None:
                movement = Vector3.zero;
                break;
        }

        transform.position += movement;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Reverse the direction when a collision occurs (same as your original code)
        switch (movementState)
        {
            case MovementState.Vertical:
                movementSpeed *= -1;
                break;
            case MovementState.Horizontal:
                movementSpeed *= -1;
                break;
            case MovementState.None:

                break;
        }
    }
}
