using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    private int levelNumber;

    private void Awake()
    {
        levelNumber = (SceneManager.GetActiveScene().buildIndex) + 1;
    }
    
    public void ClickNextLevel()
    {
        int totalLevels = SceneManager.sceneCountInBuildSettings;
        if (levelNumber == totalLevels)
        {
            PlayerPrefs.SetInt("LevelValue",2);
            int level_loop = PlayerPrefs.GetInt("level_loop");
            PlayerPrefs.SetInt("level_loop", level_loop +=1);
            SceneManager.LoadScene("Menu");
        }
        else
        {
            SceneManager.LoadScene(levelNumber);   
        }
        
        
    }

}
