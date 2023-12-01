using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameTag : MonoBehaviour
{
    private void Awake()
    {
        gameObject.tag = "InGame";
    }
}
