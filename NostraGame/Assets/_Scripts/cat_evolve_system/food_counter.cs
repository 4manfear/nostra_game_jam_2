using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class food_counter : MonoBehaviour
{
    public Slider evolve_slider;

    public int food_count;
    public int maxfood_to_evolve;

    public int minimum_food_to_evolve;

    public bool cat_stage_1 ;
    public bool cat_stage_2;
    public bool cat_stage_3;

    private void Start()
    {
        cat_stage_1 = true;
        evolve_slider.value = 0;
        evolve_slider.maxValue = maxfood_to_evolve;
    }

    private void Update()
    {
        evolve_slider.value = Mathf.Clamp(food_count, 0, maxfood_to_evolve);


        if(food_count == minimum_food_to_evolve )
        {
            evolve_the_cat();
            food_count = 0;
        }

    }

    void evolve_the_cat()
    {
        if (cat_stage_1)
        {
            cat_stage_1 = false; // Transition from stage 1
            cat_stage_2 = true;  // Move to stage 2
            Debug.Log("Evolved to Cat Stage 2");
        }
        else if (cat_stage_2)
        {
            cat_stage_2 = false; // Transition from stage 2
            cat_stage_3 = true;  // Move to stage 3
            Debug.Log("Evolved to Cat Stage 3");
        }
        else if (cat_stage_3)
        {
            Debug.Log("Cat is already at the final stage.");
        }


    }

}
