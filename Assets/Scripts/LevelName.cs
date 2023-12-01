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
        levelNumber = SceneManager.GetActiveScene().buildIndex - 1;
        _text.text = $"Level {levelNumber}";  
    }

    
}
