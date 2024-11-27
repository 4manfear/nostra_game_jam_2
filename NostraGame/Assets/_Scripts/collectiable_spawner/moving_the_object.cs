using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moving_the_object : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 2f; // Speed of movement.

    private Vector3 startPosition; // Updated to Vector3.
    private float direction = 1f; // Start moving right.

    private void Start()
    {
        startPosition = transform.position; // Capture the initial 3D position.
    }

    private void Update()
    {
        // Move the object left within the specified range.
        transform.position += Vector3.left * moveSpeed * Time.deltaTime; // Use Vector3 for movement.
    }
}
