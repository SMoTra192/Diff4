using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DailyGetInfo : MonoBehaviour
{
    private float time,timer;
    [SerializeField] private DailyTimer _timer;

    private void Awake()
    {
        _timer.GetComponent<Timer>();
        FindObjectOfType<DailyEntryPoint>().endGamedWithSuccess.AddListener(() =>
        {
            timer = time;
        });
    }

    private void Update()
    {
        time += Time.deltaTime;
        
    }

    public float Timer()
    {
        return timer;
    }
}
