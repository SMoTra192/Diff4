using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleOnStop : MonoBehaviour
{
    private void Awake()
    {
        var main = GetComponent<ParticleSystem>().main;
        main.stopAction = ParticleSystemStopAction.Callback;
    }

    private void OnParticleSystemStopped()
    {
        FindObjectOfType<CheckDetection>().checkDetect();
    }
}
