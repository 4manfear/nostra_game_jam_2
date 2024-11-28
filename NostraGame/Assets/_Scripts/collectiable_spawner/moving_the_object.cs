using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moving_the_object : MonoBehaviour
{
    public speed_of_object soo;

    public float time_to_get_destroyed_after_spawn = 10f;

    private Vector3 startPosition; // Updated to Vector3.
    private float direction = 1f; // Start moving right.

    private void Start()
    {
        startPosition = transform.position; // Capture the initial 3D position.
        Destroy(gameObject, time_to_get_destroyed_after_spawn);
    }

    private void Update()
    {
        if(soo == null)
        {
            soo = GameObject.FindObjectOfType<speed_of_object>();
        }


        // Move the object left within the specified range.
        transform.position += Vector3.left * soo.movespeed * Time.deltaTime; // Use Vector3 for movement.

        
    }
}
