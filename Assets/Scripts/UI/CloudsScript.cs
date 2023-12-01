using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CloudsScript : MonoBehaviour
{
    [SerializeField] private GameObject _cloudsOpen, _cloudsClose;
    [SerializeField] private float _secondsForWaitingSceneChange = 2f;

    private void Awake()
    {
        
    }

    public void NextLevelClouds()
    {
        StartCoroutine(waitNext());
        
    }
    public void AgainLevelClouds()
    {
        StartCoroutine(waitAgain());
    }
    public void MenuLevelClouds()
    {
        StartCoroutine(waitMenu());
    }

    public void ChosenLevel()
    {
        StartCoroutine(waitChosenLevel());
    }

    IEnumerator waitMenu()
    {
        _cloudsClose.SetActive(true);
        yield return new WaitForSeconds(_secondsForWaitingSceneChange);
        SceneManager.LoadScene("Menu");
    }
   
    IEnumerator waitAgain()
    {
        _cloudsClose.SetActive(true);
        yield return new WaitForSeconds(_secondsForWaitingSceneChange);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    IEnumerator waitNext()
    {
        _cloudsClose.SetActive(true);
        string level = SceneManager.GetActiveScene().name;
        string Level = default;
        if (level.Length == 8) Level = level.Substring(level.Length - 2);
        if (level.Length == 7) Level = level.Substring(level.Length - 1);
        if (level.Length == 9) Level = level.Substring(level.Length - 3);
        
        

        int index = int.Parse(Level);
        print(index);
        //print(SceneManager.GetActiveScene().buildIndex);
        //print(SceneManager.sceneCountInBuildSettings);
        yield return new WaitForSeconds(_secondsForWaitingSceneChange);
        if (index < PlayerPrefs.GetInt("Index"))
            SceneManager.LoadScene($"Level_{index + 1}");
        else
        {
           PlayerPrefs.DeleteAll();
           SceneManager.LoadScene("Menu");
        }
    }

    IEnumerator waitChosenLevel()
    {
        _cloudsClose.SetActive(true);
        int completedLevelIndex;
        
        yield return new WaitForSeconds(_secondsForWaitingSceneChange);
        
        completedLevelIndex = PlayerPrefs.GetInt("CompletedLevels");
        SceneManager.LoadScene($"Level_{completedLevelIndex + 1}");
    }
}
