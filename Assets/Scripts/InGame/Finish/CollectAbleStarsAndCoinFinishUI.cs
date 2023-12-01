using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectAbleStarsAndCoinFinishUI : MonoBehaviour
{
    [SerializeField] private ParticleSystem _particleStars,_particleCoins;
    [SerializeField] private CoinsParticle _coinsParticle;
    [SerializeField] private GameObject _nextButton;
    private void Awake()
    {
        _coinsParticle.GetComponent<CoinsParticle>();
        _coinsParticle.ClosePanel.AddListener(()=>gameObject.SetActive(false));
        StartCoroutine(Stars());
        StartCoroutine(Coins());
        //Startss();
    }

    private IEnumerator Stars()
    {
        print("");
        yield return new WaitForSeconds(1f);
        _particleStars.Play();
    }
    
    private IEnumerator Coins()
    {
        print("");
        yield return new WaitForSeconds(1f);
        _particleCoins.Play();
    }

    private void OnDisable()
    {
        _nextButton.SetActive(true);
    }
}
