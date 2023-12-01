using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioButton : MonoBehaviour
{
    [SerializeField] private AudioClip _audioClip;
    private Button _button;
    private AudioSource _source;
    private void Awake()
    {
        _source = GetComponent<AudioSource>();
        _button = GetComponent<Button>();
        _button.onClick.AddListener(playAudio);
    }

    private void playAudio()
    {
        _source.PlayOneShot(_audioClip);
    }
}
