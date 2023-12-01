using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CheckEffects : MonoBehaviour
{
    [SerializeField] private float timeToReactEffect = 0.2f;
    private int _winningPoints,_countOfEffects;
    private int index;
    private Transform Check, Particle;
    public UnityEvent playedEffect = new(),endEffects = new();
    //private bool startedEffects = false;
    private float _timer = 1f;
    
    private void Start()
    {
    Vibration.Init();
        _countOfEffects = gameObject.transform.childCount;
        //print(_countOfEffects);
        //Check = transform.GetChild(index);
        FindObjectOfType<EntryPoint>().startEndGameEffect.AddListener(() =>
        {
            playedEffect.Invoke();
        });
        playedEffect.AddListener(()=>StartCoroutine(PlayingEffect()));
        
    }

    private void Update()
    {

        if (index == gameObject.transform.childCount)
        {
            _timer -= Time.deltaTime;
            if(_timer <0 ) endEffects.Invoke();
            
        }
    }

    private IEnumerator PlayingEffect()
    {
        yield return new WaitForSeconds(timeToReactEffect);
        //print($"count {_countOfEffects}");
        if(index < _countOfEffects) 
        {
            Check = transform.GetChild(index);
            Check.gameObject.SetActive(false);
            Check.gameObject.SetActive(true);
            Vibration.VibrateAndroid(70);
            //Check.transform.Find("Check").transform.Find("Particle").gameObject.SetActive(true);
            //print($"started {index}");
            index++;
            playedEffect.Invoke();
        }

    }
}
