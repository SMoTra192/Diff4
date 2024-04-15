using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FinishLevelName : MonoBehaviour
{
    private int levelNumber;
    [SerializeField] private TextMeshProUGUI _text;

        void Start()
    {

        levelNumber = PlayerPrefs.GetInt("NowLevel");
        _text.text = $"Level {levelNumber}";  
    }
}
