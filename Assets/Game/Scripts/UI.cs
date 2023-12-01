using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI : MonoBehaviour
{
    private int hintsCount;
    public static string hint;
    [SerializeField] private GameObject hintPanel;
    private bool isHintClicked = false;
    
    private void Update()
    {
        hintsCount = PlayerPrefs.GetInt(hint);
    }

    public void HintClick()
    {
        if (isHintClicked == false)
        {
            PlayerPrefs.SetInt(hint, hintsCount - 1);
            hintPanel.SetActive(true);
            isHintClicked = true;
        }
    }

    public void HintClickWithoutCount()
    {
        hintPanel.SetActive(true);
    }
}
