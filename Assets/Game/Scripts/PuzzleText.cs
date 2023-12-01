using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PuzzleText : MonoBehaviour
{
    private int puzzles = 20;
    private TextMeshProUGUI _text;
    private void Awake()
    {
        _text = GetComponent<TextMeshProUGUI>();
        FindObjectOfType<TheGameEnd>()._event.AddListener(() =>
            {
                
                puzzles -= 1;
            }
            );
        
}

    private void Update()
    {
        _text.text = $"{puzzles}";
    }
}
