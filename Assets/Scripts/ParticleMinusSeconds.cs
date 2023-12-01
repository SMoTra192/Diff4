using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleMinusSeconds : MonoBehaviour
{
    private ParticleSystem _particle;

    private void Awake()
    {
        _particle = GetComponent<ParticleSystem>();
    }

    public void PlayParticle()
    {
        _particle.Play();
    }
}
