using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CoinsText : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _coinText;
    private int  coinsAmount;

    private void Update()
    {
        coinsAmount = PlayerPrefs.GetInt("CoinsAmount");
        _coinText.text = $"{coinsAmount}";
    }
    
    
    
    
}
