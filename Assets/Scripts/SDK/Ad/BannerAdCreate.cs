using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BannerAdCreate : MonoBehaviour
{
    [SerializeField] private string bannerID = "f6924db41060fb9d";
    void Start()
    {
        FindObjectOfType<MaxSdkInit>().Initialized.AddListener(() =>
        {
// Banners are automatically sized to 320×50 on phones and 728×90 on tablets
                // You may call the utility method MaxSdkUtils.isTablet() to help with view sizing adjustments
                MaxSdk.CreateBanner(bannerID, MaxSdkBase.BannerPosition.BottomCenter);
                // Set background or background color for banners to be fully functional
                MaxSdk.SetBannerBackgroundColor(bannerID, Color.clear);
    
        });
    }
        

    
}
