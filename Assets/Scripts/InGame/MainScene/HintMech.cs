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
    [SerializeField] private GameObject _coinObject;
    [SerializeField] private GameObject table;
    public UnityEvent hintPressed = new();
    private int coinAmount;

    private void Awake()
    {
        _referenceRightIcons.GetComponent<ReferenceRightIcons>();
    }

    private void Update()
    {
        coinAmount = PlayerPrefs.GetInt("CoinsAmount");
        if (coinAmount >= 15)
        {
            _coinObject.SetActive(true);
            _AdText.text = "15";
        }
        else
        {
            //_coinObject.SetActive(false);
            _AdText.text = "0";
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
            table.SetActive(true);
            print("NINE");
        }
    }
}
