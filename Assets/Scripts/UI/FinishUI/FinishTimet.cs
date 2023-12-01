using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FinishTimet : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _firstminute;
    [SerializeField] private TextMeshProUGUI _secondminute;
    [SerializeField] private TextMeshProUGUI _separator;
    [SerializeField] private TextMeshProUGUI _fisrtsecond;
    [SerializeField] private TextMeshProUGUI _secondsecond;


    [SerializeField] private GetInfo _getInfo;
    private float timer;
private void Awake()
    {
        _getInfo.GetComponent<GetInfo>();
    }

    private void Update()
    {
        if(timer == 0 ) timer = _getInfo.Timer();
        UpdateDisplay(timer);
    }

    private void UpdateDisplay(float time)
    {
        float minutes = Mathf.FloorToInt(time / 60);
        float seconds = Mathf.FloorToInt(time % 60);
        string currenttime = string.Format("{00:00}{1:00}", minutes, seconds);
        _firstminute.text = currenttime[0].ToString();
        _secondminute.text = currenttime[1].ToString();
        _fisrtsecond.text = currenttime[2].ToString();
        _secondsecond.text = currenttime[3].ToString();

    }
}
