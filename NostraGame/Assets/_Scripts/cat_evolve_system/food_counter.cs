using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class food_counter : MonoBehaviour
{
    public Slider evolve_slider;

    public int food_count;
    public int maxfood_to_evolve;

    private void Start()
    {
        evolve_slider.value = 0;
        evolve_slider.maxValue = maxfood_to_evolve;
    }

    private void Update()
    {
        evolve_slider.value = Mathf.Clamp(food_count, 0, maxfood_to_evolve);
    }

}
