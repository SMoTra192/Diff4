using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIEndGameWIthSuccess : MonoBehaviour
{
    [SerializeField] private GameObject _successUI;

    private void Awake()
    {
        FindObjectOfType<EntryPoint>().endGamedWithSuccess.AddListener(() =>
        {
            _successUI.SetActive(true);
        });
    }
}
