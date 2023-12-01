using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLevel : MonoBehaviour
{
    private int levelNumber;
    private TextMeshProUGUI _text;
    private void Awake()
    {
        _text = GetComponent<TextMeshProUGUI>();
        FindObjectOfType<EntryPoint>().endGamedWithSuccess.AddListener(() =>
        {
            
            levelNumber = SceneManager.GetActiveScene().buildIndex - 1;
            _text.text = $"Level {levelNumber}";
        });
    }
}
