using System;
using TMPro;
using UnityEngine;
using UnityEngine.Assertions.Must;
using UnityEngine.Events;

public class Timer : MonoBehaviour
{
    private float _timer;
    private float _timerduration = 3f * 60f;
    [SerializeField] private EntryPoint _entry;
    [SerializeField] private TextMeshProUGUI _firstminute;
    [SerializeField] private TextMeshProUGUI _secondminute;
    [SerializeField] private TextMeshProUGUI _separator;
    [SerializeField] private TextMeshProUGUI _fisrtsecond;
    [SerializeField] private TextMeshProUGUI _secondsecond;
    private float takenTime;
    public UnityEvent timed = new();
    private bool isVibrated;
    private bool isFinished = false;
    private bool isTimed = false;
    [SerializeField] private float  timeForGameOver = 30f;



    private void Awake()
    {
        Vibration.Init();
        _entry.GetComponent<EntryPoint>();
        FindObjectOfType<TakeTime>().timeDown.AddListener(loseTime);
    }

    void Start()
    {
        
        ResetTimer();
        takenTime = FindObjectOfType<TakeTime>().getTimeValue();
        
    }

    private void ResetTimer()
    {
        _timer = _timerduration;
    }

    private void Update()
    {
        isFinished = _entry.IsFinished();
        if (_timer > 0)
        {
           if(isFinished == false) _timer -= Time.deltaTime;
            UpdateDisplay(_timer);
        }
        //if( _timer < timeForGameOver) 
        if (_timer < timeForGameOver )
        {
            if (isTimed == false)
            {
                Vibration.VibrateAndroid(500);
                isTimed = true;
            }
            _firstminute.color = Color.red;
            _secondminute.color = Color.red;
            _separator.color = Color.red;
                _fisrtsecond.color = Color.red;
            _secondsecond.color = Color.red;
        }
        else
        {
            isTimed = false;
            _firstminute.color = Color.white;
            _secondminute.color = Color.white;
            _separator.color = Color.white;
            _fisrtsecond.color = Color.white;
            _secondsecond.color = Color.white;
        }
        //if (_timer < minTimeForFinalArea && _timer > maxTimeForFinalArea) timed.Invoke();
        // ReSharper disable once CompareOfFloatsByEqualityOperator
        //if (_timer == timeForGameOver) timed.Invoke();
    }

    private void UpdateDisplay(float time)
    {
        float minutes = Mathf.FloorToInt(time / 60);
        float seconds = Mathf.FloorToInt(time % 60);
        string currenttime = string.Format("{00:00}{1:00}", minutes, seconds);
        _firstminute.text = currenttime[0].ToString();
        _secondminute.text = currenttime[1].ToString();
        _fisrtsecond.text = currenttime[2].ToString();
        _secondsecond.text = currenttime[3].ToString();

    }

    private void loseTime()
    {
        _timer -= takenTime;
    }

    public float getTimeValue()
    {
        return _timer;
    }

    public void getExtraTime(float seconds)
    {
        _timer = 0f;
        _timer += seconds;
    }

    
}
