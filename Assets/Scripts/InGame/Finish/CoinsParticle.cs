using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CoinsParticle : FinishParticleOnStop
{
    private int _coinsAmount;
    [SerializeField] private int _giveAmount;
    public UnityEvent ClosePanel = new();
    private float _timer, startTimer;
    // Start is called before the first frame update
    private void Awake()
    {
        _coinsAmount = PlayerPrefs.GetInt("CoinsAmount");
    }

    private void OnParticleSystemStopped()
    {
        //for (int i = 0; i < _giveAmount; i++)
        {
     //    PlayerPrefs.SetInt("CoinsAmount",_coinsAmount + 1);
        }

       // StartCoroutine(wait());
        //_coinsAmount = PlayerPrefs.GetInt("CoinsAmount");
        //CoinsAmount();
        
    }

    

    private IEnumerator wait()
    {
        print("");
        yield return new WaitForSeconds(0.5f);
        ClosePanel.Invoke();
    }

}
