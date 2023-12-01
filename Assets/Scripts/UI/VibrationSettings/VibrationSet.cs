using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VibrationSet : MonoBehaviour
{
    [SerializeField] private Toggle _vibrationToggle;
    [SerializeField] private GameObject vibrationImageOn, vibrationImageOff;
    private void Awake()
    {
        _vibrationToggle.isOn = PlayerPrefs.GetInt("VibrationEnabled") == 1;
    }

    public void toggleVibration(bool EnabledVibration)
    {
        if (EnabledVibration)
        {
            vibrationImageOff.SetActive(true);
            vibrationImageOn.SetActive(false);
           // print(PlayerPrefs.GetInt("VibrationEnabled"));
        }
        else
        {
            vibrationImageOff.SetActive(false);
            vibrationImageOn.SetActive(true);
           // print(PlayerPrefs.GetInt("VibrationEnabled"));
        }
        PlayerPrefs.SetInt("VibrationEnabled", EnabledVibration ? 1 : 0);
    }
    
}