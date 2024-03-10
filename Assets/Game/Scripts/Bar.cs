using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Bar : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    private float Count,maxChildCount;
    private string SceneValue;
    float Value;
    private bool isFound = false , isFoundSceneName = false;
    private void Awake()
    {
        //SceneValue = "";
        //print(SceneManager.GetActiveScene().name);

        
            SceneValue = $"PuzzleLevel_{PlayerPrefs.GetInt("CompletedPuzzleLevels")}_Value";

    }
        
        
        
    

    private void Update()
    {
        
        Value = PlayerPrefs.GetInt(SceneValue);
        //print(Value);
        //print(Math.Abs(childCount - maxChildCount));
        _slider.value = Value / 25;
    }
}
