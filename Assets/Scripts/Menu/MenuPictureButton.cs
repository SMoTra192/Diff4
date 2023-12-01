using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

    
public class MenuPictureButton : MonoBehaviour
{
    
    [SerializeField] private GameObject completedImage, unCompletedImage,lockImage;
    
    
    private void Awake()
    {
        
    }

    private void Update()
    {
        int buttonIndex = gameObject.transform.GetSiblingIndex() + 2;
        //print($"ButtonIndex{buttonIndex}");
        int completeValueInt = PlayerPrefs.GetInt("LevelValue");
        //print($"CompleteValueIndex{completeValueInt}");
        if (buttonIndex < completeValueInt)
        {
            unCompletedImage.SetActive(false);
            completedImage.SetActive(true);
        }
        if (buttonIndex == completeValueInt)
        {
            unCompletedImage.SetActive(true);
            completedImage.SetActive(false);
        }

        if (buttonIndex > completeValueInt)
        {
            completedImage.SetActive(false);
            lockImage.SetActive(true);
        }
    }
}
