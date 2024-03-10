using System.Collections;
using System.Collections.Generic;
using Firebase.Analytics;
using Firebase.RemoteConfig;
using UnityEngine;
using UnityEngine.Events;

public class FirebaseStart : MonoBehaviour
{
    private bool ischecked = false;

    public UnityEvent Firebased = new();
    // Start is called before the first frame update
    void Start()
    {
        Firebase.FirebaseApp.CheckAndFixDependenciesAsync().ContinueWith(task => {
            var dependencyStatus = task.Result;
            if (dependencyStatus == Firebase.DependencyStatus.Available) {
                // Create and hold a reference to your FirebaseApp,
                // where app is a Firebase.FirebaseApp property of your application class.
                var app = Firebase.FirebaseApp.DefaultInstance;
                FirebaseRemoteConfig.DefaultInstance.FetchAsync();
                FirebaseRemoteConfig.DefaultInstance.ActivateAsync();
                ischecked = true;
                // Set a flag here to indicate whether Firebase is ready to use by your app.
            } else {
                UnityEngine.Debug.LogError(System.String.Format(
                    "Could not resolve all Firebase dependencies: {0}", dependencyStatus));
                ischecked = true;
                // Firebase Unity SDK is not safe to use here.
            }
            
        });
        if(ischecked)FirebaseAnalytics.LogEvent("open_app"); 
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
