using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JSON : MonoBehaviour
{
    private serialize ser = new serialize();

    private void Awake()
    {
    }
}

[System.Serializable]
public class serialize
{
    private string name;
    private int age;
        
}
