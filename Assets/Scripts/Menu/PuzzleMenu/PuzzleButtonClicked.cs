using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PuzzleButtonClicked : MonoBehaviour
{
    private int indexButton;
    [SerializeField] private Button _button;
    [SerializeField] private GameObject _cloudsClose;
    private void Awake()
    {
        indexButton = transform.GetSiblingIndex() + 1;
        _button.onClick.AddListener(()=>StartCoroutine(waitAgain()));
    }
    IEnumerator waitAgain()
    {
        indexButton = gameObject.transform.GetSiblingIndex() + 1;
        //int completeLevel = PlayerPrefs.GetInt("PuzzleLevelValue");
       // print(indexButton);
        //print(completeLevel);
        //if(indexButton <= completeLevel) 
        _cloudsClose.SetActive(true);
        yield return new WaitForSeconds(1f);
        //(indexButton <= completeLevel)
        SceneManager.LoadScene($"PuzzleLevel_{indexButton}");
    }
    
    
}
