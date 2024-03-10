using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class IconsValue : MonoBehaviour
{
    
    private List<TextMeshProUGUI> _iconTexts;
    [SerializeField] private GameObject[] _iconObjects;

    private void Start()
    {
        _iconTexts = new List<TextMeshProUGUI>();
        _iconTexts.Add(FindObjectOfType<Text1>().GetComponent<TextMeshProUGUI>());
        _iconTexts.Add(FindObjectOfType<Text2>().GetComponent<TextMeshProUGUI>());
        _iconTexts.Add(FindObjectOfType<Text3>().GetComponent<TextMeshProUGUI>());
        print(_iconTexts.Count);
        
        for (int i = 1; i <= _iconObjects.Length; i++)
        {
            _iconTexts[i-1].text = $"{_iconObjects[i-1].transform.childCount}";
            PlayerPrefs.SetInt($"Icons{i}Value", _iconObjects[i-1].transform.childCount);
            
        }
        
            
       
    }

    private void Update()
    {
        _iconTexts[0].text = $"{PlayerPrefs.GetInt($"Icons1Value")}";
        _iconTexts[1].text = $"{PlayerPrefs.GetInt($"Icons2Value")}";
        _iconTexts[2].text = $"{PlayerPrefs.GetInt($"Icons3Value")}";
    }
}
