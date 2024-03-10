using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LucyAndJack : MonoBehaviour
{
    [SerializeField] private GameObject _lucy, _jack;

    private void Awake()
    {
        if ((PlayerPrefs.GetInt("CompletedPuzzleLevels") - 1) > 10)
        {
            _lucy.SetActive(false);
            _jack.SetActive(true);
        }
    }
}
