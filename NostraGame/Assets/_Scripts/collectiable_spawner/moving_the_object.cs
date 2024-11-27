using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moving_the_object : MonoBehaviour
{
    public speed_of_object soo;
    
    

    private Vector3 startPosition; // Updated to Vector3.
    private float direction = 1f; // Start moving right.

    private void Start()
    {
        startPosition = transform.position; // Capture the initial 3D position.
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
