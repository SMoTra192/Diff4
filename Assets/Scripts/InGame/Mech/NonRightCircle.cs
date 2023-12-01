using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NonRightCircle : MonoBehaviour
{
    private float _timer;

    private void Awake()
    {
        _timer = 0.4f;
    }

    private void Update()
    {
        _timer -= Time.deltaTime;
        if(_timer<0 ) Destroy(gameObject);
    }
}
