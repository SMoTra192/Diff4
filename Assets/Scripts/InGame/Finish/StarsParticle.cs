using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarsParticle : FinishParticleOnStop
{
    private int _starsAmount;
    [SerializeField] private int _giveAmount;
    private void Awake()
    {
        _starsAmount = PlayerPrefs.GetInt("StarsAmount");
        // Stars - Кол-во паззлов
    }

    private void OnParticleSystemStopped()
    {
        PlayerPrefs.SetInt("StarsAmount",_starsAmount + _giveAmount);
        _starsAmount = PlayerPrefs.GetInt("StarsAmount");
        StarsAmount();
    }

    public int StarsAmount()
    {
        return _starsAmount;
    }
}
