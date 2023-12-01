using System;
using System.Collections;
using System.Collections.Generic;
using System.Timers;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using Random = UnityEngine.Random;

public class ProgressFiller : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private float _minTime, _maxTime;
    [SerializeField] public int _minValue = 2, _maxValue = 5;
    [SerializeField] private String _keyValue;
    private int _ItemValue;
    private void Start()
    {
        int Coin = PlayerPrefs.GetInt(_keyValue);
        int NextCoin;
        _ItemValue = Random.Range(_minValue, _maxValue);
        NextCoin = _ItemValue + Coin;
        SetProgress(Coin,NextCoin);
        PlayerPrefs.SetInt(_keyValue,NextCoin);
}

    private void SetProgress(float Value, float endValue)
    {
        float normalizedValue = Value / endValue;
        float duration = Mathf.Lerp(_minTime, _maxTime, normalizedValue);
        StartCoroutine(LerpValue(Value, endValue, duration, SetValue));
    }
    
    private IEnumerator LerpValue(float startValue, float endValue, float duration, UnityAction<float> action)
    {
        float elasped = 0;
        float nextValue;

        while (elasped < duration)
        {
            nextValue = Mathf.Lerp(startValue, endValue, elasped / duration);
            action?.Invoke(nextValue);
            elasped += Time.deltaTime;
            yield return null;
        }
        action?.Invoke(endValue);
    }

    private void SetValue(float Value)
    {
        Value = (int)Value;
        _text.text = $"{Value}";
    }
}
