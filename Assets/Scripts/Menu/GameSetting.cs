using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSetting : MonoBehaviour
{
    private void Awake()
    {
        //PlayerPrefs.SetInt("level_count",PlayerPrefs.GetInt("level_count") + 1);
        Application.targetFrameRate = 60;
    }
}
