using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIEndGame : MonoBehaviour
{
    [SerializeField] private GameObject UIEndGamePanel;
    [SerializeField] private ParticleSystem[] _particles;
    [SerializeField] private GameObject gamePlay;
    [SerializeField] private GameObject[] UIToHide;
    

    public void ShowPanel()
    {
        UIEndGamePanel.SetActive(true);
    }

    public void ShowParticles()
    {
        foreach (var particle in _particles)
        {
            particle.gameObject.SetActive(true);
            particle.Play();
        }
    }
    
    public void HideObjects()
    {
        gamePlay.SetActive(false);

        foreach (var UI in UIToHide)
        {
            UI.SetActive(false);
        }
    }
    public void HidePanel()
    {
        UIEndGamePanel.SetActive(false);
    }

    public void HideParticles()
    {
        foreach (var particle in _particles)
        {
            particle.gameObject.SetActive(false);
            particle.Stop();
        }
    }
    public void ShowObjects()
    {
        gamePlay.SetActive(true);

        foreach (var UI in UIToHide)
        {
            UI.SetActive(true);
        }
    }
}
