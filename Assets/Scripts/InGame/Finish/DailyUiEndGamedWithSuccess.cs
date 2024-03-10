using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DailyUiEndGamedWithSuccess : MonoBehaviour
{
    [SerializeField] private GameObject _successUI,_progressFiller,_coinsParticleSystem;
    [SerializeField] private AudioSource _source;

    private void Awake()
    {
        FindObjectOfType<DailyEntryPoint>().endGamedWithDailySuccess.AddListener(() =>
        {
            StartCoroutine(Image());
            PlayerPrefs.SetInt("Salut", 0);
        });
    }
    private IEnumerator Image()
    {
        int dailyIndex = PlayerPrefs.GetInt("Daily");
        PlayerPrefs.SetInt("Daily",dailyIndex + 1);
        yield return new WaitForSeconds(0.5f);
        _successUI.SetActive(true);
        yield return new WaitForSeconds(2.7f);
        _coinsParticleSystem.gameObject.SetActive(true);
        _progressFiller.SetActive(true);
        _source.PlayOneShot(_source.clip);
        yield return new WaitForSeconds(4f);
        _successUI.SetActive(false);
        SceneManager.LoadScene("Menu");
    }
}