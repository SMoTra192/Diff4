using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class HintMech : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _AdText;
    [SerializeField] private ReferenceRightIcons _referenceRightIcons;
    [SerializeField] private GameObject StarsImage,AdImage,ADForHint;
    public UnityEvent hintPressed = new();
    private int coinAmount,AdsValue;

    private void Awake()
    {
        _referenceRightIcons.GetComponent<ReferenceRightIcons>();
    }

    private void Update()
    {
        coinAmount = PlayerPrefs.GetInt("CoinsAmount");
        if (coinAmount >= 15)
        {
            StarsImage.SetActive(true);
            _AdText.text = "15";
        }
        else
        {
            AdsValue = PlayerPrefs.GetInt("ADSDisable");
            if (AdsValue == 0)
            {
                _AdText.text = "Ad";
                AdImage.SetActive(true);
            }
            else
            {
                _AdText.text = "15";
                StarsImage.SetActive(true);
            }
            //_coinObject.SetActive(false);
            
        }
    }

    public void Click()
    {
        if (coinAmount >= 15)
        {
            _referenceRightIcons.CheckHint();
            _referenceRightIcons.CheckHint2();
            hintPressed.Invoke();
            PlayerPrefs.SetInt("CoinsAmount",coinAmount - 15);
        }
        else
        {
            AdsValue = PlayerPrefs.GetInt("ADSDisable");
            if (AdsValue == 0)
            {
                MaxSdk.ShowRewardedAd("7da19e7b39044227");
                _referenceRightIcons.CheckHint();
                _referenceRightIcons.CheckHint2();
                hintPressed.Invoke();
            }
            else
            {
                ADForHint.SetActive(true);
            }
            
        }
    }
}
