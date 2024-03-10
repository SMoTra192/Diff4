using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonClicked : MonoBehaviour
{
    private Button _button;
    private int indexButton;
    [SerializeField] private GameObject _cloudsClose;
    private void Awake()
    {
        _button = gameObject.GetComponent<Button>();
        _button.onClick.AddListener(()=>
        {
            StartCoroutine(waitAgain());
        });
        
    }
    
    IEnumerator waitAgain()
    {
        int index = gameObject.transform.GetSiblingIndex() + 1;
        PlayerPrefs.SetInt("NowLevel",index);
        print(index);
        indexButton = gameObject.transform.GetSiblingIndex();
        int completeLevel = PlayerPrefs.GetInt("CompletedLevels");
        if(indexButton < completeLevel + 1) _cloudsClose.SetActive(true);
        yield return new WaitForSeconds(1f);
        if(indexButton < completeLevel + 1) SceneManager.LoadScene("Level_1");
        
    }
    private void Update()
    {
        //print(gameObject.transform.GetSiblingIndex());
        //print(PlayerPrefs.GetInt("LevelValue"));
    }
}
