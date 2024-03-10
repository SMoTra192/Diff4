using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarsParticle1 : MonoBehaviour
{
    [SerializeField] private ParticleSystem[] _particleSystem;

    private void OnEnable()
    {
        StartCoroutine(starsGo());
        
    }

    private IEnumerator starsGo()
    {
        yield return new WaitForSeconds(2f);
        foreach (var _particle in _particleSystem)
        {
            _particle.Play();
        }
        
    }
}
