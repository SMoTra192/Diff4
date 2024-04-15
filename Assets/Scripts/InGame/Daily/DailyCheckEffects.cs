using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class DailyCheckEffects : MonoBehaviour
{
    [SerializeField] private float timeToReactEffect = 0.2f;
    private int _countOfEffects;
    private int index;
    private Transform Check;
    public UnityEvent playedEffect = new(),endEffects = new();
    private float _timer = 1f;
    
    private void Start()
    {
        Vibration.Init();
        if(SceneManager.GetActiveScene().name == "Level_1")
        {FindObjectOfType<LevelImagesInstance>().onSpot.AddListener(() =>
        {
            _countOfEffects = gameObject.transform.childCount;
        });}
        else
        {
            _countOfEffects = gameObject.transform.childCount; 
        }

        FindObjectOfType<DailyEntryPoint>().startEndGameEffect.AddListener(() =>
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
        
        if(index < _countOfEffects) 
        {

            Check = transform.GetChild(index);
            Check.gameObject.SetActive(false);
            Check.gameObject.SetActive(true);
            Vibration.VibrateAndroid(70);
        
            index++;
            playedEffect.Invoke();
        }

    }
}
