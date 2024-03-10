using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableAd : MonoBehaviour
{
    private void Start()
    {
        PlayerPrefs.SetInt("ADSDisable",1);
        MaxSdk.HideBanner("f6924db41060fb9d");
    }

    public void DisableAds()
    {
        PlayerPrefs.SetInt("ADSDisable",1);
        MaxSdk.HideBanner("f6924db41060fb9d");
    }
}
