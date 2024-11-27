using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class making_paws_all_lsound : MonoBehaviour
{
    public bool all_Audio_pause;

    private void Awake()
    {
        AudioListener.pause = all_Audio_pause;

    }
}
