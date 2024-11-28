using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;
using UnityEngine.UI;

public class Coin_Collection : MonoBehaviour
{// this script should be added on the coins 


    [SerializeField]
    private Coins coin_scritable_object;// this is the scritable object

    


   


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Cat") || collision.gameObject.CompareTag("Player"))
        {
            coin_scritable_object.Dubloons++;
            Destroy(this.gameObject);

        }
    }
}
