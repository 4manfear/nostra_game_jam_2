using System;
using System.Numerics;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Tilemaps;


public class patteren_spawner : MonoBehaviour
{
    [SerializeField]
    private Transform spawnPosition;

    [SerializeField]
    private GameObject spawnPatternObject;

    [SerializeField]
    private float timeGap = 2f; // Time gap between spawns.

    public float spawnTimer;

    public int randomNumber;
    private void Update()
    {
        // Decrease timer.
        spawnTimer -= Time.deltaTime;

        // If the timer reaches zero, spawn an object.
        if (spawnTimer <= 0)
        {
            SpawnPattern();
            spawnTimer = timeGap; // Reset timer.
        }

        
    }

    private void SpawnPattern()
    {
        randomNumber = UnityEngine.Random.Range(0, 6); // Generate random number.
        Debug.Log("Generated Random Number: " + randomNumber);

        if (randomNumber == 0) // Spawn only if the random number is 0.
        {
            Instantiate(spawnPatternObject, spawnPosition.position, UnityEngine.Quaternion.identity);
        }
    }

    


}
