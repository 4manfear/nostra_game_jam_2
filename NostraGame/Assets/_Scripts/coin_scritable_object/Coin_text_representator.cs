using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class Coin_text_representator : MonoBehaviour
{
    public Coins coins;

    public TextMeshProUGUI texp_for_the_coin;

    private void Update()
    {
        texp_for_the_coin.text = coins.Dubloons.ToString();
    }

}
