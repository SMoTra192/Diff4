using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class TapObject : MonoBehaviour
{
    [SerializeField] private GameObject _objectToHide, _objectToInst;
    private Button _thisButton;
    
    private void Start()
    {
        _thisButton = GetComponent<Button>();
        _thisButton.onClick.AddListener(() =>
        {
            if(gameObject.tag == "Object1") PlayerPrefs.SetInt("Icons1Value",PlayerPrefs.GetInt("Icons1Value") - 1);
            if(gameObject.tag == "Object2") PlayerPrefs.SetInt("Icons2Value",PlayerPrefs.GetInt("Icons2Value") - 1);
            if(gameObject.tag == "Object3") PlayerPrefs.SetInt("Icons3Value",PlayerPrefs.GetInt("Icons3Value") - 1);
            StartCoroutine(iwait());
            _thisButton.interactable = false;
        });
    }


    private IEnumerator iwait()
    {
        _objectToHide.SetActive(false);
        _objectToInst.SetActive(true);
        if(gameObject.transform.childCount >= 3) Destroy(gameObject.transform.GetChild(gameObject.transform.childCount - 1).gameObject);
        yield return new WaitForSeconds(1.5f);
        _objectToInst.SetActive(false);
    }
}
