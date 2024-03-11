using System;
using System.Collections;
using System.Collections.Generic;
using Firebase.Analytics;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class EntryPoint : MonoBehaviour
{
    [SerializeField] private Timer _timer;
    [SerializeField] private UIEndGame _endGame;
    [SerializeField] private CheckDetection _check;
    private float time,timeForGameOver,timerForFinishStart = 1f;
    private int _winningPoints, pointsToWin;
    public UnityEvent endGamed = new();
    public UnityEvent endGamedWithSuccess = new(),startEndGameEffect = new() , endGamedWithDailySuccess = new();
    public UnityEvent Tutorialed = new();
    private bool isEndGamedWithSuccess =false;
    private bool isFinished = false,isTimerStart = false;
    private float startTime;
    private GameObject[] stars = new GameObject[3];
    
    [SerializeField] private GameObject _counter;
    [SerializeField] private GameObject iconsParent;
    [SerializeField] private AudioSource _sourceDiffIcons;

    private bool isInstanceReady = false;
    private bool isFin = false;
    void Start()
    {
        FindObjectOfType<LevelImagesInstance>().onSpot.AddListener(() =>
        {
            print("hello24");
            isInstanceReady = true;
        });
        if(SceneManager.GetActiveScene().name == "Level_1")
            GameObject.Find("Canvas").transform.GetChild(5).gameObject.SetActive(true);
        else
        {
            GameObject.Find("Canvas").transform.GetChild(4).gameObject.SetActive(true);
        }
        stars[0] = GameObject.Find("Star");
        stars[2] = GameObject.Find("Star 2");
        stars[1] = GameObject.Find("Star Big");
        if(GameObject.Find("FinishUI") != null) GameObject.Find("FinishUI").SetActive(false);
        //print(stars[0].name);
        _timer.GetComponent<Timer>();
        _endGame.GetComponent<UIEndGame>();
        _check.GetComponent<CheckDetection>();
        endGamed.AddListener(endGameCanvas);

if(SceneManager.GetActiveScene().name == "Level_1")
{
    FindObjectOfType<LevelImagesInstance>().onSpot.AddListener(() =>
{
    pointsToWin = FindObjectOfType<CheckDetection>().transform.childCount;
   // print(pointsToWin);
});
}
else
{
    pointsToWin = FindObjectOfType<CheckDetection>().transform.childCount;
    //print(pointsToWin);
}
        
        FindObjectOfType<ReferenceIdentification>().ReferenceTouched.AddListener(() =>
        {
            _winningPoints = _check.WinningPoints();
            //print(_winningPoints);
        FindObjectOfType<CheckEffects>().endEffects.AddListener(()=> isEndGamedWithSuccess = true);        
            

        });
    }


    private void Update()
    {
        if (isInstanceReady)
        {


            if (_winningPoints == pointsToWin)
            {
                timerForFinishStart -= Time.deltaTime;
                isFin = true;

            }

            if (_winningPoints == pointsToWin && timerForFinishStart < 0 && isFinished == false)
            {
                FirebaseAnalytics.LogEvent("win_level", "level", "level index");
                // print("sucC");
                if (_counter != null) _counter.SetActive(true);
                _sourceDiffIcons.Play();
                startEndGameEffect.Invoke();
                isFinished = true;
            }

            time = _timer.getTimeValue();
            if (!isTimerStart)
            {
                startTime = time;
                isTimerStart = true;
            }

            //
            if (stars[0] != null) stars[0].SetActive(true);
            if (time < startTime - 60f && stars[1] != null)
            {
                stars[1].SetActive(false);
            }

            if (time < startTime - 120f && stars[2] != null)
            {
                stars[2].SetActive(false);
            }

            if (time > startTime - 180f) PlayerPrefs.SetInt("CoinToGive", 1);
            if (time > startTime - 120f) PlayerPrefs.SetInt("CoinToGive", 2);
            if (time > startTime - 60f) PlayerPrefs.SetInt("CoinToGive", 3);



            if (time < 1f)
            {
                if (PlayerPrefs.GetInt("LoseLevel") == 0)
                {
                    PlayerPrefs.SetInt("LoseLevel", 1);
                    FirebaseAnalytics.LogEvent("lose_level", "level", "level index");
                }

                endGamed?.Invoke();
            }

            if (_winningPoints == pointsToWin && isEndGamedWithSuccess == true)
            {
                //print("succ");
                if (PlayerPrefs.GetInt("DailyLevelPlaying") == 1)
                {
                    if (PlayerPrefs.GetInt("DailyLevelEnded") == 0) PlayerPrefs.SetInt("DailyLevelEnded", 1);
                    endGamedWithDailySuccess.Invoke();
                    int DailyIndex = PlayerPrefs.GetInt("Daily");
                    PlayerPrefs.SetInt("Daily", DailyIndex + 1);
                    PlayerPrefs.SetInt("DailyLevelPlaying", 0);
                }

                endGamedWithSuccess.Invoke();
            }

        }
    }

    private void endGameCanvas()
    {
        _endGame.ShowPanel();
        _endGame.HideObjects();
        _endGame.ShowParticles();
    }

    public void ExtraTimeCanvas()
    {
        _endGame.HidePanel();
        _endGame.HideParticles();
        _endGame.ShowObjects();
    }
    
    public bool IsFinished()
    {
        return isFinished;
    }

    public bool IsFin()
    {
        return isFin;
    }
}