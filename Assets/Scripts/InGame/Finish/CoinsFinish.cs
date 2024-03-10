using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinsFinish : MonoBehaviour
{
    private void Awake()
    {
        PlayerPrefs.SetInt("CoinsAmount",PlayerPrefs.GetInt("CoinsAmount") + PlayerPrefs.GetInt("CoinToGive"));
    }

    public void CoinsX5()
    {
        PlayerPrefs.SetInt("CoinsAmount",PlayerPrefs.GetInt("CoinsAmount") - PlayerPrefs.GetInt("CoinToGive"));
        int St = PlayerPrefs.GetInt("CoinToGive") * 5;
        PlayerPrefs.SetInt("CoinsAmount",PlayerPrefs.GetInt("CoinsAmount") + St);
    }
}
