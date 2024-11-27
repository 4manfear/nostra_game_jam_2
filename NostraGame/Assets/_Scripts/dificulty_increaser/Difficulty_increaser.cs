using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Difficulty_increaser : MonoBehaviour
{
    public speed_of_object soo;

    private void Update()
    {
        
    }

    private void Start()
    {
        InvokeRepeating("difficulty_increase_function", 0f, 20f);
    }
    void difficulty_increase_function()
    {
        soo.movespeed += 2;
        Debug.Log("20 second completed");
    }

}
