using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Images : MonoBehaviour
{
    [SerializeField] private Image image1, image2, image3;
    private Sprite _sprite;

    private void Start()
    {
        
        _sprite = Resources.Load<Sprite>($"Levels/Hidden/{PlayerPrefs.GetInt("CompletedHiddenLevels")}/Image1");
        image1.sprite = _sprite;
        _sprite = Resources.Load<Sprite>($"Levels/Hidden/{PlayerPrefs.GetInt("CompletedHiddenLevels")}/Image2");
        image2.sprite = _sprite;
        _sprite = Resources.Load<Sprite>($"Levels/Hidden/{PlayerPrefs.GetInt("CompletedHiddenLevels")}/Image3");
        image3.sprite = _sprite;
    }
}
