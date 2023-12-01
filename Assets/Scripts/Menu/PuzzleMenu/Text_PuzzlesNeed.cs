using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Text_PuzzlesNeed : MonoBehaviour
{ 
    private Transform _textParent;
    private TextMeshProUGUI _text;
    private int _puzzlesCount;
    private void Awake()
    {
        _textParent = gameObject.transform.parent.
            transform.parent;
        _text = GetComponent<TextMeshProUGUI>();
        _puzzlesCount = PlayerPrefs.GetInt("StarsAmount");
    }

    private void Update()
    {
        
        _text.text = $"{_puzzlesCount}/{(_textParent.transform.GetSiblingIndex() + 1) * 20}";
    }
}
