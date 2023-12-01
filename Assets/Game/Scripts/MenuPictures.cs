using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPictures : MonoBehaviour
{
    private int currentValueCompletedLevels;
    private int sceneIndex;

    private void Update()
    {
        sceneIndex = (SceneManager.GetActiveScene().buildIndex);
        //print($"sceneIndex" + sceneIndex);
        currentValueCompletedLevels = PlayerPrefs.GetInt("LevelValue");
        //print("currentValueComp" + currentValueCompletedLevels);
        if (sceneIndex >= currentValueCompletedLevels) PlayerPrefs.SetInt("LevelValue", currentValueCompletedLevels += 1);
       //print("afterLevel" + currentValueCompletedLevels);
    }
}
