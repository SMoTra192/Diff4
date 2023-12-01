using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Onclick : MonoBehaviour
{
    private UnityEvent clickedOn = new();
    [SerializeField] private GameObject image;
    private void Awake()
    {
        clickedOn.AddListener(()=>
            image.SetActive(true));
    }

    public void clickClack()
    {
        clickedOn.Invoke();
    }
    
}
