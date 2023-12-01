using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinsAndStarsObjectEnable : MonoBehaviour
{
    [SerializeField] private GameObject _gameObject;
    private float timer = 0;
    private bool isStarted = false;
    private void Awake()
    {
        //StartCoroutine(Object());
    }

    private void Update()
    {
        timer += Time.deltaTime;
        if (timer > 0.2f && !isStarted)
        {
            StartCoroutine(Object());
            isStarted = true;
        }
    }

    private IEnumerator Object()
    {
       ///// print("");
        yield return new WaitForSeconds(2f);
        _gameObject.SetActive(true);
        yield return new WaitForSeconds(4.1f);
        if(PlayerPrefs.GetInt("Tutorial") == 1)FindObjectOfType<EntryPoint>().Tutorialed.Invoke();
    }
}
