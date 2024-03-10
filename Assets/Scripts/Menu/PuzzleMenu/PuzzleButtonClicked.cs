using System;
using System.Collections;
using System.Collections.Generic;
using Firebase.Analytics;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PuzzleButtonClicked : MonoBehaviour
{
    
    [SerializeField] private Button _button;
    [SerializeField] private GameObject _cloudsClose;
    private void Awake()
    {
        _button.onClick.AddListener(()=>StartCoroutine(waitAgain()));
    }
    IEnumerator waitAgain()
    {
        _cloudsClose.SetActive(true);
        FirebaseAnalytics.LogEvent("play_puzzle","level","level index");
        yield return new WaitForSeconds(1f);
        PlayerPrefs.SetInt("PuzzleLevelLoad",transform.GetSiblingIndex()+1);
        SceneManager.LoadScene($"PuzzleLevel");
    }
    
    
}
