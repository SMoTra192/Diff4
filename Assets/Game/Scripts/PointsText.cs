using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PointsText : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI pointsText;
    private int points;
    private void Awake()
    {
        pointsText.GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
        points = PlayerPrefs.GetInt(Points.keyPoints);
        pointsText.text = $"{points}";
        
    }
}
