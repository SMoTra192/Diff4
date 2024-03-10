using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollRollScript : MonoBehaviour
{
    private RectTransform tr,child;
    private float PosX;
    private void Awake()
    {
        int PuzzleLevelValue = PlayerPrefs.GetInt("CompletedPuzzleLevels");
        PosX = gameObject.transform.position.x;
        //gameObject.transform.position = new Vector3(PosX - (4.94f * (PuzzleLevelValue - 1)),  
          //  transform.position.y, transform.position.z);
         // gameObject.transform.position = gameObject.transform.GetChild(PuzzleLevelValue).gameObject.transform.position;
         //child = 
        // tr.anchoredPosition
    }
    
}
