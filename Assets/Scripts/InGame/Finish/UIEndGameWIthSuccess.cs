using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIEndGameWIthSuccess : MonoBehaviour
{
    [SerializeField] private GameObject _successUI;
    [SerializeField]  private GameObject _ZatemnenieObj;
    

    private void Awake()
    {
        FindObjectOfType<EntryPoint>().endGamedWithSuccess.AddListener(() =>
        {
            StartCoroutine(iwait());
        });
    }
    private IEnumerator iwait()
    {
    yield return new WaitUntil(()=> FindObjectOfType<CheckEffects>().Index() == FindObjectOfType<CheckEffects>().CountOfEffects());

    yield return new WaitForSeconds(0.5f);
    _ZatemnenieObj.SetActive(true);
    yield return new WaitForSeconds(1);
    _successUI.SetActive(true);
    }
}
