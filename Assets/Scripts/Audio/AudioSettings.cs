using System;
using System.Collections;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioSettings : MonoBehaviour
{
    [SerializeField] private AudioMixerGroup Master;
    [SerializeField] private Toggle _toggleMusic,_toggleEffects;
    [SerializeField] private GameObject effectsOn, effectsOff,
        musicOn,musicOff;

    

    
    private void Start()
    {
        _toggleMusic.isOn = PlayerPrefs.GetInt("MusicEnabled") == 1;
        _toggleEffects.isOn = PlayerPrefs.GetInt("EffectsEnabled") == 1;
        if (PlayerPrefs.GetInt("MusicEnabled") == 0)
        {
            musicOn.SetActive(true);
            musicOff.SetActive(false);
            Master.audioMixer.SetFloat("Music", 0);
        }
        else
        {
            musicOn.SetActive(false);
            musicOff.SetActive(true);
            Master.audioMixer.SetFloat("Music", -80);
        }
        if (PlayerPrefs.GetInt("EffectsEnabled") == 0)
        {
            effectsOn.SetActive(true);
            effectsOff.SetActive(false);
            Master.audioMixer.SetFloat("Effects", 0);
        }
        else
        {
            effectsOn.SetActive(false);
            effectsOff.SetActive(true);
            Master.audioMixer.SetFloat("Effects", -80);
        }
    }


    public void ToggleMusic(bool enabledMusic)
    {
        if (enabledMusic)
        {
            musicOn.SetActive(false);
            musicOff.SetActive(true);
            Master.audioMixer.SetFloat("Music", -80);
        }
        else 
        {
            musicOn.SetActive(true);
            musicOff.SetActive(false);
            Master.audioMixer.SetFloat("Music", 0);
            
        }
        PlayerPrefs.SetInt("MusicEnabled", enabledMusic ? 1 : 0);
    }
    
    public void ToggleEffects(bool enabledEffects)
    {
        if (enabledEffects)
        {
            effectsOn.SetActive(false);
            effectsOff.SetActive(true);
           Master.audioMixer.SetFloat("Effects", -80);
        }
        else 
        {
            
            effectsOn.SetActive(true);
            effectsOff.SetActive(false);
            Master.audioMixer.SetFloat("Effects", 0);
            
        }
        PlayerPrefs.SetInt("EffectsEnabled", enabledEffects ? 1 : 0);
    }

    
}