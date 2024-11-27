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

    public TextMeshProUGUI coint_text_represntatro;

    private void Update()
    {
        coint_text_represntatro.text =coin_scritable_object.Dubloons.ToString();
        if (coin_scritable_object == null)
        {
            coin_scritable_object = FindAnyObjectByType<Coins>();
        }

    }

   


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Cat"))
        {
            coin_scritable_object.Dubloons++;
            Destroy(this.gameObject);

        }
    }
}
