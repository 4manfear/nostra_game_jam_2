using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cat_random_movement : MonoBehaviour
{
    public Transform[] anchorPoints; // Array of anchor points to move around.
    public float moveRadius = 5f; // Radius within which the player moves randomly.
    public float moveSpeed = 2f; // Speed of movement.
    public float rotationSpeed = 5f; // Speed of rotation towards the anchor.

    private Transform currentAnchorPoint; // The current anchor point.
    private Vector2 randomTargetPosition;

    private void Start()
    {
        if (anchorPoints.Length == 0)
        {
            Debug.LogError("No anchor points assigned!");
            return;
        }

        // Assign an initial random anchor point and target position.
        currentAnchorPoint = anchorPoints[Random.Range(0, anchorPoints.Length)];
        SetRandomTargetPosition();
    }

    private void Update()
    {
        if (currentAnchorPoint == null)
            return;

        MoveTowardsTarget();
        RotateTowardsTarget();

        // Check if the player has reached the target position.
        if (Vector2.Distance(transform.position, randomTargetPosition) < 0.1f)
        {
            // Set a new random target position when the current one is reached.
            SetRandomTargetPosition();
        }
    }

    void MoveTowardsTarget()
    {
        // Move towards the target position.
        transform.position = Vector2.MoveTowards(
            transform.position,
            randomTargetPosition,
            moveSpeed * Time.deltaTime
        );
    }

    void RotateTowardsTarget()
    {
        // Determine the direction to the target.
        Vector2 direction = randomTargetPosition - (Vector2)transform.position;

        // Flip the Y rotation based on the X direction.
        if (direction.x > 0) // Moving right
        {
            transform.rotation = Quaternion.Euler(0, 0, 0); // Face right
        }
        else if (direction.x < 0) // Moving left
        {
            transform.rotation = Quaternion.Euler(0, 180, 0); // Face left
        }
    }

    void SetRandomTargetPosition()
    {
        // Generate a random point within the radius around the current anchor point.
        Vector2 randomOffset = Random.insideUnitCircle * moveRadius;
        randomTargetPosition = (Vector2)currentAnchorPoint.position + randomOffset;

        // Optionally switch to a new anchor point at random intervals.
        if (Random.value > 0.8f) // 20% chance to switch anchor points.
        {
            currentAnchorPoint = anchorPoints[Random.Range(0, anchorPoints.Length)];
        }
    }
}
