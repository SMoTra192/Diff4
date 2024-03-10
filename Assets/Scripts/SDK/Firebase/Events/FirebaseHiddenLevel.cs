using System.Collections;
using System.Collections.Generic;
using Firebase.Analytics;
using UnityEngine;

public class FirebaseHiddenLevel : MonoBehaviour
{
    
    void Start()
    {
        
        if(PlayerPrefs.GetInt($"EnteredHiddenLevel{PlayerPrefs.GetInt("CompletedHiddenLevels")}") == 0) FirebaseAnalytics.LogEvent("HiddenLevel_start","level","level index");
        PlayerPrefs.SetInt($"EnteredHiddenLevel{PlayerPrefs.GetInt("CompletedHiddenLevels")}",1);
    }

    
}
