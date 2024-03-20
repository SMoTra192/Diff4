using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstGameStart : MonoBehaviour
{
    private string firstStart;
    private void Awake()
    {
        firstStart = "FirstStartGame";
        if (PlayerPrefs.GetInt(firstStart) == 0)
        {
            //PlayerPrefs.SetInt(UI.hint,2);
            PlayerPrefs.SetInt("Tutorial",0);
            PlayerPrefs.SetInt("PuzzlesTutorial", 0);
            PlayerPrefs.SetInt("LevelValue",2);
            PlayerPrefs.SetInt("StarsAmount",0);
            PlayerPrefs.SetInt("CoinsAmount",15);
            PlayerPrefs.SetInt("CompletedLevels",0);
            PlayerPrefs.SetInt("Daily",1);
            PlayerPrefs.SetInt("CompletedPuzzleLevels",1);
            PlayerPrefs.SetInt("CompletedHiddenLevels",1);
            PlayerPrefs.SetString("DayOfWeek",DateTime.Now.DayOfWeek.ToString());
            PlayerPrefs.SetInt("ADSDisable",0);
           // MaxSdk.HideBanner("f6924db41060fb9d");
            
        }
        PlayerPrefs.SetInt(firstStart,1);
        
    }
    
}
