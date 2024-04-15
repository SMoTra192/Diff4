using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BannerAd : MonoBehaviour
{
    [SerializeField] private string bannerID = "f6924db41060fb9d";
    [SerializeField] private bool isDevelopMode;
    private int AdsValue;

    private void Start()
    {
        
        AdsValue = PlayerPrefs.GetInt("ADSDisable");
        InitializeBannerAds();
    }

    public void InitializeBannerAds()
    {
        if (!isDevelopMode && AdsValue == 0)
        {
            if (SceneManager.GetActiveScene().name == "Menu" ||
                SceneManager.GetActiveScene().name == "Puzzle_menu") MaxSdk.HideBanner(bannerID);
            else
            {
                MaxSdk.ShowBanner(bannerID);
            }
        }

    }
    
}
    


 
