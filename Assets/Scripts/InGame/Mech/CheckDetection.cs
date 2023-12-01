using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CheckDetection : MonoBehaviour
{
    private int index;
    private Transform check;
    private bool isRefensered = false;
    private void Awake()
    {
        index = 0;
        FindObjectOfType<ReferenceIdentification>().ReferenceTouched.AddListener(() =>
        {
            if (index < gameObject.transform.childCount)
            {
                check = gameObject.transform.GetChild(index);
                gameObject.transform.GetChild(index);
                
                index++;
                checkDetect();
            }
        });
        
    }

    public void checkDetect()
    {
        check.gameObject.transform.GetChild(0).gameObject.SetActive(false);
        check.gameObject.transform.GetChild(1).gameObject.SetActive(true);
    }

    public int WinningPoints()
    {
        return index;
    }

    public int PointsToWin()
    {
        return gameObject.transform.childCount;
    }

    

    
}
