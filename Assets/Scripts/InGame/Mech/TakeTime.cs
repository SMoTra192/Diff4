using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TakeTime : MonoBehaviour
{
    [SerializeField] private float timeValue = 15f;
    public UnityEvent timeDown = new();

    private void Awake()
    {
        timeDown.AddListener(() =>
        {
            FindObjectOfType<ParticleMinusSeconds>().PlayParticle();
        });
    }

    public float getTimeValue()
    {
        return timeValue;
    }
}
