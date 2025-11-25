using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelPositionMenu : MonoBehaviour
{
    [SerializeField]private RectTransform content;

    [SerializeField] private int completedLevels;

    private Vector2 pos;
    // Start is called before the first frame update 185
    void Start()
    {
        content.sizeDelta = new Vector2(content.sizeDelta.x,content.transform.GetChild(0).transform.childCount * 200 );
        pos = content.anchoredPosition;
        completedLevels = PlayerPrefs.GetInt("CompletedLevels");
        var comp = Math.Round((decimal)completedLevels  / 2);
        
        if(completedLevels/2 == comp) content.anchoredPosition = new Vector3(pos.x,
            pos.y + (385f * completedLevels / 2) - 385f);
        else
        {
        
            content.anchoredPosition = new Vector3(pos.x,
                pos.y + (385f * ( (completedLevels- 1) / 2) ) - 385f );
        }
        
        
        if (completedLevels == 0) content.anchoredPosition = new Vector3(pos.x,
            pos.y);  
        if (completedLevels == 1) content.anchoredPosition = new Vector3(pos.x,
            pos.y);    
    }


}
