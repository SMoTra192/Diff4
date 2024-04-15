using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DailyUiEndGamedWithSuccess : MonoBehaviour
{
    [SerializeField] private GameObject _cloudsClose;
    
    private void Awake()
    {
        FindObjectOfType<DailyEntryPoint>().endGamedWithDailySuccess.AddListener(() =>
        {
            StartCoroutine(Image());
            PlayerPrefs.SetInt("Salut", 0);
        });
    }
    private IEnumerator Image()
    {
        int dailyIndex = PlayerPrefs.GetInt("Daily");
        PlayerPrefs.SetInt("Daily",dailyIndex + 1);
        PlayerPrefs.SetInt("CountDailyLevelCompleted",PlayerPrefs.GetInt("CountDailyLevelCompleted")+1);
        yield return new WaitForSeconds(1.5f);

        _cloudsClose.SetActive(true);

        yield return new WaitForSeconds(1.5f);

        if(PlayerPrefs.GetInt("CountDailyLevelCompleted") >= 2) 
                        if(PlayerPrefs.GetInt("DailyLevelEnded") == 0) 
                            PlayerPrefs.SetInt("DailyLevelEnded",1);

        if(PlayerPrefs.GetInt("CountDailyLevelCompleted") < 2)
        {
                FindObjectOfType<AdsCheck>().InterAd();
                SceneManager.LoadScene("DailyLevel_1");
        }
        else
        {
                FindObjectOfType<AdsCheck>().InterAd();
                SceneManager.LoadScene("Menu");
        }
    }
}