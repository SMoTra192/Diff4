using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLevel : MonoBehaviour
{
    
    private TextMeshProUGUI _text;
    private void Awake()
    {
        _text = GetComponent<TextMeshProUGUI>();
        FindObjectOfType<EntryPoint>().endGamedWithSuccess.AddListener(() =>
        {
            
            _text.text = $"Level {PlayerPrefs.GetInt("NowLevel")}";
        });
    }
}
