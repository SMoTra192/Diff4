using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButton : MonoBehaviour
{
    public void ButtonMenu()
    {
        if (PlayerPrefs.GetInt("DailyLevelPlaying") == 1)
        {
            //if(PlayerPrefs.GetInt("DailyLevelEnded") == 0) PlayerPrefs.SetInt("DailyLevelEnded",1);
            PlayerPrefs.SetInt("DailyLevelPlaying",0);
        }
        SceneManager.LoadScene("Menu");
    }
}
