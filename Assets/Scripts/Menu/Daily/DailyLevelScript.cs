using System;
using System.Collections;
using System.Collections.Generic;
using Firebase.Analytics;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DailyLevelScript : MonoBehaviour
{
    private int dailyIndex;
    private Button _button;
    [SerializeField] private GameObject completedImage, nonCompleted,completedImageWithoutAnimation,Salut,_cloudsClose;
    private void Awake()
    {
        _button = GetComponent<Button>();
        dailyIndex = PlayerPrefs.GetInt("Daily");
        int dailyLevelEnded = PlayerPrefs.GetInt("DailyLevelEnded");
        nonCompleted.SetActive(true);
        if (dailyLevelEnded == 1)
        {
            nonCompleted.SetActive(false);
            if(PlayerPrefs.GetInt("Salut") == 1)completedImageWithoutAnimation.SetActive(true);
            else
            {
                completedImage.SetActive(true);
                Salut.SetActive(true);
                PlayerPrefs.SetInt("Salut", 1);
            }
        }
        _button.onClick.AddListener(() =>
        {
            PlayerPrefs.SetInt("DailyLevelPlaying", 1);
            FirebaseAnalytics.LogEvent("play_daily");
            StartCoroutine(Image());
        });
    }
    
    private IEnumerator Image()
    {
        yield return new WaitForSeconds(0.1f);
        _cloudsClose.SetActive(true);
        yield return new WaitForSeconds(1f);
        if(PlayerPrefs.GetInt("DailyNowLevel") == 0) PlayerPrefs.SetInt("DailyNowLevel",1);
        SceneManager.LoadScene($"DailyLevel_1");
        
    }
}
