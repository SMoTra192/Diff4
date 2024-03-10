using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StarsText : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI[] _starsText;
    private int  starsAmount;

    
    private void Update()
    {
        
        starsAmount = PlayerPrefs.GetInt("StarsAmount");

        foreach (var _starsText in _starsText)
        {
            _starsText.text = $"{starsAmount}";
        }

        
        
    }
}
