using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class coin_texting_representator : MonoBehaviour
{
    [SerializeField]
    private Coins coin_scritable_object;
    public TextMeshProUGUI coint_text_represntatro;

    private void Update()
    {
        coint_text_represntatro.text = coin_scritable_object.Dubloons.ToString();
    }
}
