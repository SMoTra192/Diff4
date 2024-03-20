using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableAd : MonoBehaviour
{
    private void Start()
    {
        if(PlayerPrefs.GetInt("ADSDisable") == 1) MaxSdk.HideBanner("f6924db41060fb9d");
    }

    
}
