using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Firebase.RemoteConfig;
using UnityEngine;
using UnityEngine.Events;

public class Values : MonoBehaviour
{
    
    private float timer;
    [SerializeField] private bool isDevelopMode;
    public UnityEvent timed = new();
    void Start()
    {
        GameObject interv = GameObject.FindWithTag("Interval");
        if (interv == null) gameObject.tag = "Interval";
        else
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(gameObject);
        
            FirebaseRemoteConfig.DefaultInstance.FetchAndActivateAsync();
            var value = FirebaseRemoteConfig.DefaultInstance.GetValue("interval_time");
            timer = 60f;
            
            print(timer);
            timed.Invoke();
            timed.AddListener(() =>
            {
                timer = 60f;
            });
    }



    private void Update()
    {
        if(!isDevelopMode) timer -= Time.deltaTime;
    }

    public float Timer()
    {
        return timer;
    }
}
