using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button_Play : MonoBehaviour
{
    [SerializeField] private GameObject _poolOfItems, _poolSpace;
    [SerializeField] private GameObject _buttonPlay;

    private bool isChecked = false;
    private void Update()
    {
        if(_poolOfItems == null) _poolOfItems = GameObject.Find("PoolOfItems");
        if (_poolSpace == null) _poolSpace = GameObject.Find("PoolSpace");
        int starsAmount = PlayerPrefs.GetInt("StarsAmount");
        for (int i = 0; i < _poolOfItems.transform.childCount; i++)
        {
            if (!_poolOfItems.transform.GetChild(i).gameObject.activeInHierarchy) isChecked = true;
            else
            {
                isChecked = false;
            }
            
        }
        if( isChecked && starsAmount == 0 && _poolSpace.transform.childCount == 0) _buttonPlay.SetActive(true);
    }
}
