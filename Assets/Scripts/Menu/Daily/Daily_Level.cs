using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Daily_Level : MonoBehaviour
{
    private string dayData;
    public UnityEvent isDated = new();
    private void Awake()
    {
        string Day;
        string Data;
        
        Day = "DayOfWeek";
        Data = PlayerPrefs.GetString(Day);
        //print(Data);
        dayData = DateTime.Now.DayOfWeek.ToString();
        if (Data != dayData)
        {
            PlayerPrefs.SetString(Day,dayData);
            PlayerPrefs.SetInt("DailyLevelEnded",0);
        }
        else
        {
            //print("Hey"); 
        }
        
       
        

        
        
        
    }
}
