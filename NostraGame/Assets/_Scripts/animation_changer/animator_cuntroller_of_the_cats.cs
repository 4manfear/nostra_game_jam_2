using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animator_cuntroller_of_the_cats : MonoBehaviour
{// this script should be insiside the cat

    public Animator anim;

    public food_counter foodcounter;


    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if(foodcounter==null)
        {
            foodcounter = GameObject.FindObjectOfType<food_counter>();  
        }

        if(foodcounter.cat_stage_1)
        {
            // put the first cat animation over here 
        }
        if (foodcounter.cat_stage_2)
        {
            // put the second animation the second stage of the cat over here 
        }
        if (foodcounter.cat_stage_3)
        {
            // put the third animaion over here (anim.setbool("animation_name", true)
        }

    }

}
