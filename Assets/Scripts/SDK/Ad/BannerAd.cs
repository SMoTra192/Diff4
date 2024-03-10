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
        if(AdsValue == 1) MaxSdk.HideBanner(bannerID);
    }

    public void InitializeBannerAds()
    {
        if (!isDevelopMode)
        {
            if (SceneManager.GetActiveScene().name == "Menu" ||
                SceneManager.GetActiveScene().name == "Puzzle_menu") MaxSdk.HideBanner(bannerID);
            else
            {
                // Banners are automatically sized to 320×50 on phones and 728×90 on tablets
                // You may call the utility method MaxSdkUtils.isTablet() to help with view sizing adjustments
                MaxSdk.CreateBanner(bannerID, MaxSdkBase.BannerPosition.BottomCenter);
                // Set background or background color for banners to be fully functional
                MaxSdk.SetBannerBackgroundColor(bannerID, Color.clear);
                MaxSdk.ShowBanner(bannerID);
            }
        }

    }
    
}
    


 
