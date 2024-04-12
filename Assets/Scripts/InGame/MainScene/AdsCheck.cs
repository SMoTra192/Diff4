using System;
using System.Collections;
using System.Collections.Generic;
using AppsFlyerSDK;
using Unity.VisualScripting;
using UnityEngine;

public class AdsCheck : MonoBehaviour

{
    private Values _values;
    
    

    private void Awake()
    {
       
        _values = GameObject.Find("Interval_timer").GetComponent<Values>();
        //if(_values != null) print("hi");
    }

    public void InterAd()
    {
        float timer = _values.Timer();
        if (PlayerPrefs.GetInt("NowLevel") > 1)
        {
            print(timer);
            if (timer < 0)
            {
                PlayerPrefs.SetInt("Inter",PlayerPrefs.GetInt("Inter") + 1);
                Dictionary<string, string> AFIntersEvent = new Dictionary<string, string>();
                AFIntersEvent.Add("InterAd","1");
                FindObjectOfType<Values>().timed.Invoke();  
                AppsFlyer.sendEvent("af_inters",AFIntersEvent);
                FindObjectOfType<InterstitalAd>().showInterstitalAd();
            }
        }
       
        
        

        
    }

    public void RewAd()
    {
        Dictionary<string, string> AFIntersEvent = new Dictionary<string, string>();
        AFIntersEvent.Add("RewardedAd","1");
        AppsFlyer.sendEvent("af_rewarded",AFIntersEvent);
        FindObjectOfType<RewardedAd>().ShowAd();
        
    }

    public void GetTimeForInter()
    {
        //_values.timed.Invoke();
    }
}
