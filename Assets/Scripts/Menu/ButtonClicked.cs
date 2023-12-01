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
        //index = gameObject.transform.GetSiblingIndex() + 1;
        indexButton = gameObject.transform.GetSiblingIndex() + 2;
        int completeLevel = PlayerPrefs.GetInt("LevelValue");
        if(indexButton < completeLevel + 1) _cloudsClose.SetActive(true);
        yield return new WaitForSeconds(1f);
        if(indexButton < completeLevel + 1) SceneManager.LoadScene(indexButton);
    }
    private void Update()
    {
        //print(gameObject.transform.GetSiblingIndex());
        //print(PlayerPrefs.GetInt("LevelValue"));
    }
}
