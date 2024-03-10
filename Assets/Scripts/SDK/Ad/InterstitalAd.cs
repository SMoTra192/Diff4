using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InterstitalAd : MonoBehaviour
{
    
    [SerializeField] string adUnitId = "ae1e7e3d895f34a1"; 
    
    int retryAttempt;
    private int interval_time;
    private int AdsValue;
    public UnityEvent aDsTimed = new();
    private void Start()
    {
        GameObject interv = GameObject.FindWithTag("Ads");
        if (interv == null) gameObject.tag = "Ads";
        else
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(gameObject);
        aDsTimed.AddListener(() =>
        {
            AdsValue = PlayerPrefs.GetInt("ADSDisable");
            if(AdsValue == 0)MaxSdk.ShowInterstitial(adUnitId);
        });
        
        
        InitializeInterstitialAds();
    }

    public void showInterstitalAd()
    {
        
           aDsTimed.Invoke();
    }

    public void InitializeInterstitialAds()
    {
        // Attach callback
        MaxSdkCallbacks.Interstitial.OnAdLoadedEvent += OnInterstitialLoadedEvent;
        MaxSdkCallbacks.Interstitial.OnAdLoadFailedEvent += OnInterstitialLoadFailedEvent;
        MaxSdkCallbacks.Interstitial.OnAdDisplayedEvent += OnInterstitialDisplayedEvent;
        MaxSdkCallbacks.Interstitial.OnAdClickedEvent += OnInterstitialClickedEvent;
        MaxSdkCallbacks.Interstitial.OnAdHiddenEvent += OnInterstitialHiddenEvent;
        MaxSdkCallbacks.Interstitial.OnAdDisplayFailedEvent += OnInterstitialAdFailedToDisplayEvent;
        // Load the first interstitial
        LoadInterstitial();
    }
    private void LoadInterstitial()
    {
        MaxSdk.LoadInterstitial(adUnitId);
    }
    private void OnInterstitialLoadedEvent(string adUnitId, MaxSdkBase.AdInfo adInfo)
    {
        // Interstitial ad is ready for you to show. MaxSdk.IsInterstitialReady(adUnitId) now returns 'true'
        // Reset retry attempt
        retryAttempt = 0;
    }
    private void OnInterstitialLoadFailedEvent(string adUnitId, MaxSdkBase.ErrorInfo errorInfo)
    {
        // Interstitial ad failed to load 
        // AppLovin recommends that you retry with exponentially higher delays, up to a maximum delay (in this case 64 seconds)
        retryAttempt++;
        double retryDelay = Math.Pow(2, Math.Min(6, retryAttempt));    
        Invoke("LoadInterstitial", (float) retryDelay);
    }

    private void OnInterstitialDisplayedEvent(string adUnitId, MaxSdkBase.AdInfo adInfo)
    {
        
    }
    private void OnInterstitialAdFailedToDisplayEvent(string adUnitId, MaxSdkBase.ErrorInfo errorInfo, MaxSdkBase.AdInfo adInfo)
    {
        // Interstitial ad failed to display. AppLovin recommends that you load the next ad.
        LoadInterstitial();
    }
    private void OnInterstitialClickedEvent(string adUnitId, MaxSdkBase.AdInfo adInfo) {}
    private void OnInterstitialHiddenEvent(string adUnitId, MaxSdkBase.AdInfo adInfo)
    {
        // Interstitial ad is hidden. Pre-load the next ad.
        LoadInterstitial();
    }
    
}
