using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelName : MonoBehaviour
{
    private int levelNumber;
    [SerializeField] private TextMeshProUGUI _text;

        void Start()
    {
        levelNumber = PlayerPrefs.GetInt("NowLevel");
        _text.text = $"Lv {levelNumber}";  
    }

    
}
