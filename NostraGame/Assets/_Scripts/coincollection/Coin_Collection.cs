using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;
using UnityEngine.UI;

public class Coin_Collection : MonoBehaviour
{
    [SerializeField]
    private Coins coin_scritable_object;

    


   


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Cat"))
        {
            coin_scritable_object.Dubloons++;
            Destroy(this.gameObject);

        }
    }
}
