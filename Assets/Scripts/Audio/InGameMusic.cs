using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameMusic : MonoBehaviour
{
    private string[] tag;
    private void Awake()
    {
        tag = new string[2];
        tag[0] = "Menu";
        tag[1] = "Puzzle_Menu";
        foreach (var tag in tag)
        {
            GameObject obj = GameObject.FindWithTag(tag);
            Destroy(obj);
            
        }

        string newTag = "InGame";
        GameObject obj2 = GameObject.FindWithTag(newTag);
        if(obj2 != null) Destroy(gameObject);
        else
        {
            gameObject.tag = newTag;
            DontDestroyOnLoad(gameObject);
        }
    }
}
