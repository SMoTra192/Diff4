using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HomeButton : MonoBehaviour
{
    [SerializeField] private Button _button;
    [SerializeField] private string HomeName;
    private int completedLevelIndex;
    private void Awake()
    {
        //
    }

    public void Home()
    {
        SceneManager.LoadScene(HomeName);
    }
}
