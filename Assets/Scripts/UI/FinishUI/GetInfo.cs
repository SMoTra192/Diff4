using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GetInfo : MonoBehaviour
{
    private float time,timer;
    [SerializeField] private Timer _timer;

    private void Awake()
    {
        _timer.GetComponent<Timer>();
        FindObjectOfType<EntryPoint>().endGamedWithSuccess.AddListener(() =>
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
