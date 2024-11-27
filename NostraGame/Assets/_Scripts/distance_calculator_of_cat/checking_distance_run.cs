using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class checking_distance_run : MonoBehaviour
{
    public float meters_checkier;

    [SerializeField]
    private TextMeshProUGUI meters_representator;


    

    private void LateUpdate()
    {
        meters_checkier += Time.deltaTime;

        meters_representator.text = meters_checkier.ToString("F1");
    }
}
