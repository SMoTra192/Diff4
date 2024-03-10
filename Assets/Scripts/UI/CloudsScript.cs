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

    public void HiddenLevel()
    {

        StartCoroutine(waitHiddenLevel());
    }

    public void HiddenContinue()
    {
        StartCoroutine(waitHiddenContinue());
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
        PlayerPrefs.SetInt("LoseLevel", 0);
        yield return new WaitForSeconds(_secondsForWaitingSceneChange);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    IEnumerator waitNext()
    {
        _cloudsClose.SetActive(true);
        yield return new WaitForSeconds(_secondsForWaitingSceneChange);
        int nowLevel = PlayerPrefs.GetInt("NowLevel");
        PlayerPrefs.SetInt("NowLevel", nowLevel + 1);
        SceneManager.LoadScene("Level_1");

    }

    IEnumerator waitChosenLevel()
    {
        _cloudsClose.SetActive(true);
        int completedLevelIndex;

        yield return new WaitForSeconds(_secondsForWaitingSceneChange);

        completedLevelIndex = PlayerPrefs.GetInt("CompletedLevels");
        PlayerPrefs.SetInt("NowLevel", completedLevelIndex + 1);
        SceneManager.LoadScene($"Level_1");
    }

    IEnumerator waitHiddenLevel()
    {
        _cloudsClose.SetActive(true);
        int completedLevelIndex;

        yield return new WaitForSeconds(_secondsForWaitingSceneChange);

        completedLevelIndex = PlayerPrefs.GetInt($"LoadedLevel{PlayerPrefs.GetInt("CompletedHiddenLevels")}");
        int coins = PlayerPrefs.GetInt("CoinsAmount");
        if (completedLevelIndex == 0) PlayerPrefs.SetInt("CoinsAmount", coins - PlayerPrefs.GetInt("_coinsToUnlock"));

        SceneManager.LoadScene($"Hidden_Level");

    }

    IEnumerator waitHiddenContinue()
    {
        _cloudsClose.SetActive(true);
        yield return new WaitForSeconds(_secondsForWaitingSceneChange);
        if (PlayerPrefs.GetInt("CoinsAmount") < PlayerPrefs.GetInt("_coinsToUnlock")) SceneManager.LoadScene("Menu");
        else
        {
            _secondsForWaitingSceneChange = 0.1f;
            StartCoroutine(waitHiddenLevel());
        }
    }


}
