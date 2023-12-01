using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VibrationOnEnable : MonoBehaviour
{
    private void Awake()
    {
        Vibration.Init();
    }

    private void OnEnable()
    {
        Vibration.VibrateAndroid(35);
    }
}
