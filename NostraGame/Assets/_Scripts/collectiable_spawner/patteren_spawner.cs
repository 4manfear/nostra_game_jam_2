using System;
using System.Numerics;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Tilemaps;


public class patteren_spawner : MonoBehaviour
{
    [Header("obsical collecting variables")]
    [SerializeField]
    private Transform obsical_spawner_position;
    [SerializeField]
    private GameObject mouse;
    [SerializeField]
    private GameObject wall;
    public bool mouse_canspawn;
    [SerializeField]
    private float time_gap_for_wall_and_mouse;
    public float wam_time_gap;
    public int randomnumber_for_mouse_and_wall;



    [Header("coin collecting variables")]
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

        time_gap_for_wall_and_mouse -= Time.deltaTime;
        if(time_gap_for_wall_and_mouse <=0)
        {
            if(mouse_canspawn)
            {
                canspawnboth_random();
            }
            else
            {
                only_wall_can_spawn();
            }
            time_gap_for_wall_and_mouse = wam_time_gap;
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

    void canspawnboth_random()
    {
        randomnumber_for_mouse_and_wall = UnityEngine.Random.Range(0, 6);
        if(randomnumber_for_mouse_and_wall / 2==0 )
        {
            Debug.Log("yo it is divisible" + randomnumber_for_mouse_and_wall);
        }
        else if(randomnumber_for_mouse_and_wall /2!=0)
        {
            Debug.Log("it is not dividible" + randomnumber_for_mouse_and_wall);
        }

        
    }

    void only_wall_can_spawn()
    {
        Instantiate(wall, obsical_spawner_position.position, UnityEngine.Quaternion.identity);
    }
    


}
