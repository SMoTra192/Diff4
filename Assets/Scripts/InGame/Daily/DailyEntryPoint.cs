using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class DailyEntryPoint : MonoBehaviour
{
    [SerializeField] private DailyTimer _timer;
    [SerializeField] private UIEndGame _endGame;
    [SerializeField] private CheckDetection _check;
    private float time,timeForGameOver,timerForFinishStart = 1f;
    private int _winningPoints, pointsToWin;
    public UnityEvent endGamed = new();
    public UnityEvent endGamedWithSuccess = new(),startEndGameEffect = new() , endGamedWithDailySuccess = new();
    public UnityEvent Tutorialed = new();
    private bool isEndGamedWithSuccess =false;
    private bool isFinished = false,isTimerStart = false,isDailyStaged = false;
    private float startTime;
    private GameObject[] stars = new GameObject[3];
    
    [SerializeField] private GameObject _counter;
    [SerializeField] private GameObject iconsParent;
    [SerializeField] private AudioSource _sourceDiffIcons;
    
    
    private bool isFin = false;
    void Start()
    {
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
        endGamed.AddListener(()=>
        {
            print("ADSAWDAWDA2");
        });


pointsToWin = FindObjectOfType<CheckDetection>().transform.childCount;
        FindObjectOfType<ReferenceIdentification>().ReferenceTouched.AddListener(() =>
        {
            _winningPoints = _check.WinningPoints();
        FindObjectOfType<DailyCheckEffects>().endEffects.AddListener(()=> isEndGamedWithSuccess = true);        
            

        });
    }
    

    private void Update()
    {
        
        if (_winningPoints == pointsToWin)
        {
            timerForFinishStart -= Time.deltaTime;
            isFin = true;
            
        }
        
        if (_winningPoints == pointsToWin && timerForFinishStart < 0 && isFinished == false)
        {
           // print("sucC");
            if(_counter != null)_counter.SetActive(true);
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
       if(stars[0] != null) stars[0].SetActive(true);
       if (time < startTime - 60f && stars[1] != null) stars[1].SetActive(false);
       if(time < startTime - 120f && stars[2] != null) stars[2].SetActive(false);



       if (time < 1f)
       {
           endGamed?.Invoke();
       }
       
             if (_winningPoints == pointsToWin && isEndGamedWithSuccess == true )
             {
                 
                 if (PlayerPrefs.GetInt("DailyLevelPlaying") == 1 && !isDailyStaged)
                 {
                     
                     PlayerPrefs.SetInt("DailyNowLevel",PlayerPrefs.GetInt("DailyNowLevel") + 1);
                     endGamedWithDailySuccess.Invoke();
                     Tutorialed.Invoke();
                     int DailyIndex = PlayerPrefs.GetInt("Daily");
                     PlayerPrefs.SetInt("Daily",DailyIndex + 1);
                     if(PlayerPrefs.GetInt("CountDailyLevelCompleted") >= 2) PlayerPrefs.SetInt("DailyLevelPlaying",0);
                     isDailyStaged = true;
                     
                 }
                 endGamedWithSuccess.Invoke();
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
