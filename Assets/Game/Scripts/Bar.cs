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
        for (int x = 0; x < SceneManager.sceneCountInBuildSettings; x++)
        {
            if ($"{SceneManager.GetActiveScene().name}" == $"PuzzleLevel_{x}")
            {
                isFoundSceneName = true;
                //print("isFoundSceneName");
                //print(SceneManager.GetActiveScene().name);
                //print($"PuzzleLevel_{x}");
            }
        }
        for (int i = 0; i < 3; ++i)
        {
            if (!isFoundSceneName)
            {
              // print("true");
               SceneValue = $"PuzzleLevel_{gameObject.transform.parent.transform.parent.GetSiblingIndex() + 1}_Value";
              // print(SceneValue);
               isFound = true;
            }
            
            else
            {
                SceneValue = $"{SceneManager.GetActiveScene().name}_Value";
                //print(SceneValue);
                isFound = true;
            }
        }
        
        
        
    }

    private void Update()
    {
        
        Value = PlayerPrefs.GetInt(SceneValue);
        //print(Value);
        //print(Math.Abs(childCount - maxChildCount));
        _slider.value = Value / 25;
    }
}
