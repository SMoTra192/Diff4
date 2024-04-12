using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HiddenLevelInLevel : MonoBehaviour
{
   private int _coinAmount;
    [SerializeField] private int _coinsToUnlock = 30;
    [SerializeField] private GameObject _cloudObject;

    private Button _button;
    
    // Update is called once per frame
    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    void Awake()
    {
        _button = GetComponent<Button>();
        PlayerPrefs.SetInt("_coinsToUnlock",_coinsToUnlock);

        if (PlayerPrefs.GetInt("CoinsAmount") < _coinsToUnlock && PlayerPrefs.GetInt($"LoadedLevel{PlayerPrefs.GetInt("CompletedHiddenLevels")}") == 0)
        {
            _button.onClick.AddListener(()=>
            {
            _cloudObject.SetActive(true);
            });
            
        }
        else
        {
            _button.onClick.AddListener
            (
                ()=>
            {
                FindObjectOfType<CloudsScript>().HiddenLevel();
            });
        }
    }
    
}
