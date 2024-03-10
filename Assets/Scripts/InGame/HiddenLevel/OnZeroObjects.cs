using System;
using System.Collections;
using System.Collections.Generic;
using Firebase.Analytics;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;

public class OnZeroObjects : MonoBehaviour
{
    private bool isFirstZero = false, isSecondZero = false, isThirdZero = false;
    private bool isAllThreeObjActivated = false;
    [SerializeField] private GameObject[] checks;
    [SerializeField] private GameObject _finishObj;
    [SerializeField] private ParticleSystem[] _particle;
    private int _value;
    public UnityEvent Finished = new();
    private bool isCreated = false;
    private void Start()
    {
        FindObjectOfType<ProgressionLoading>().Created.AddListener(() =>
        {
            isCreated = true;
        });
        Finished.AddListener(() =>
        {
            
            PlayerPrefs.SetInt("CompletedHiddenLevels",PlayerPrefs.GetInt("CompletedHiddenLevels") + 1);
            StartCoroutine(iwait());
        });
    }

    private void Update()
    {
        if (isCreated)
        {
            _value = PlayerPrefs.GetInt($"Icons1Value");
            print(_value);
            if (_value == 0 && isFirstZero == false)
            {
                checks[0].gameObject.SetActive(true);
                isFirstZero = true;
            }
            _value = PlayerPrefs.GetInt($"Icons2Value");
            print(_value);
            if (_value == 0 && isSecondZero == false)
            {
                checks[1].gameObject.SetActive(true);
                isSecondZero = true;
            }
            _value = PlayerPrefs.GetInt($"Icons3Value");
            print(_value);
            if (_value == 0 && isThirdZero == false)
            {
                checks[2].gameObject.SetActive(true);
                isThirdZero = true;
            }
        }
        

        if (isFirstZero == true && isSecondZero == true && isThirdZero == true && isAllThreeObjActivated == false)
        {
            isAllThreeObjActivated = true;
            FirebaseAnalytics.LogEvent("HiddenLevel_finish","level","level index");
            Finished.Invoke();
        }
    }

    private IEnumerator iwait()
    {
        foreach (var _part in _particle)
        {
            _part.Play();
        }

        yield return new WaitForSeconds(1f);
        _finishObj.SetActive(true);
    }
    
}
