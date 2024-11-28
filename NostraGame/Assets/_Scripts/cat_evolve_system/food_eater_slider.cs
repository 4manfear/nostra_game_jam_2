using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class food_eater_slider : MonoBehaviour
{
    public food_counter fc;



    private void Update()
    {
        fc  = GameObject.FindFirstObjectByType<food_counter>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Cat") || collision.gameObject.CompareTag("Player") )
        {
            fc.food_count++;
            Destroy(this.gameObject);
        }
    }

}
