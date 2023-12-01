using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarsProgressFIller : ProgressFiller
{
    private void Awake()
    {
        _minValue = 1;
        _maxValue = 3;
    }
}
