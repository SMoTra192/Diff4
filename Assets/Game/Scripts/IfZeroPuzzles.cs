using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class IfZeroPuzzles : MonoBehaviour
{
    [SerializeField] private GameObject button,_poolOfItemsParent;
    private bool isNull;
    void Start()
    {
        
        int StarsValue = PlayerPrefs.GetInt("StarsAmount");
        for (int i = 0; i < _poolOfItemsParent.transform.childCount; i++)
        {
            if (_poolOfItemsParent.transform.GetChild(i).gameObject.activeInHierarchy) isNull = true;
        }

        //print(StarsValue);
        if(StarsValue == 0 && !isNull) button.gameObject.SetActive(true);
    }

    
    
}
