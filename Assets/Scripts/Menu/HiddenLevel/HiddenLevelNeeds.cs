using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HiddenLevelNeeds : MonoBehaviour
{
    private int _coinAmount;
    [SerializeField] private int _coinsToUnlock = 30;
    [SerializeField] private GameObject _lessNeeds, _moreneeds;
    
    // Update is called once per frame
    void Update()
    {
        PlayerPrefs.SetInt("_coinsToUnlock",_coinsToUnlock);
        if (PlayerPrefs.GetInt("CoinsAmount") < _coinsToUnlock && PlayerPrefs.GetInt($"LoadedLevel{PlayerPrefs.GetInt("CompletedHiddenLevels")}") == 0)
        {
            _lessNeeds.SetActive(true);
            _moreneeds.SetActive(false);
        }
        else
        {
            _moreneeds.SetActive(true);
            _lessNeeds.SetActive(false);
        }
        
    }
}
