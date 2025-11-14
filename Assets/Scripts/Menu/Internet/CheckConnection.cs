using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class CheckConnection : MonoBehaviour
{
    private InternetReq _internetReq;
    public UnityEvent InternetIsChecked = new();
    private UnityEvent timeToCheck = new();
    private float timer = 3f;
    private GameObject _failedGM;
    private GameObject IntObj;
    void Start()
    {
        _internetReq = GetComponent<InternetReq>();
        _failedGM = FindObjectOfType<Internet_object>().gameObject;
        IntObj = _failedGM;
        _failedGM.SetActive(false);
        
        StartCoroutine(_internetReq.TestConnection(result => 
            {
                print($"Internet connection is {result}");
                if (result) StartCoroutine(iwait());
                if(!result) _failedGM.SetActive(true);
            }));
        
        
        float startTimer = timer;
        
        timeToCheck.AddListener(()
            =>
        {
            timer = startTimer;
            StartCoroutine(_internetReq.TestConnection(result => 
            {
                print($"Internet connection is {result}");
                if (result) StartCoroutine(iwait());
                if(!result) _failedGM.SetActive(true);
            }));
        });
        InternetIsChecked.AddListener(() =>
        {
            _failedGM.SetActive(false);
        });
        

    }

    private void Update()
    {
        
            if (_failedGM == null)
            {
                _failedGM = FindObjectOfType<Internet_object>().gameObject;
                _failedGM.SetActive(false);
            }

            if (_failedGM != null)
            {
                if(!_failedGM.activeInHierarchy)timer -= Time.deltaTime;
            }
        
            if(timer <= 0) timeToCheck.Invoke();
        
        
    }


    private IEnumerator iwait()
    {
        yield return null;
        InternetIsChecked.Invoke();
    }

    public void CheckConn()
    {
        StartCoroutine(_internetReq.TestConnection(result => 
        {
            print($"Internet connection is {result}");
            if (result) StartCoroutine(iwait());
            if(!result) _failedGM.SetActive(true);
        }));
    }

    void InvokeIntObj()
    {
        IntObj.SetActive(true);
    }

     void SetObjFalse()
    {
        IntObj.SetActive(false);
    }
}
