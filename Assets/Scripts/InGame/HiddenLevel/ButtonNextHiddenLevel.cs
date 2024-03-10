using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonNextHiddenLevel : MonoBehaviour
{
    private Button _button;
    void Start()
    {
        print(PlayerPrefs.GetInt("CoinsAmount"));
        _button = GetComponent<Button>();
        _button.onClick.AddListener(() =>
        {
            int coinsAmount = PlayerPrefs.GetInt("CoinsAmount");
            if (coinsAmount > PlayerPrefs.GetInt("_coinsToUnlock"))
            {
                print(PlayerPrefs.GetInt("CoinsAmount"));
                PlayerPrefs.SetInt("CoinsAmount",PlayerPrefs.GetInt("CoinsAmount") - PlayerPrefs.GetInt("_coinsToUnlock"));
                SceneManager.LoadScene("Hidden_Level");
            }
            else
            {
                SceneManager.LoadScene("Menu");
            }
        });
    }

   
}
