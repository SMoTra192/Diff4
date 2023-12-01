using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class TheGameEnd : MonoBehaviour
{
    [SerializeField] private GameObject poolOfItemsFolder,
         effectOnEnd3,
        hints,
        Bar,
        itemsOnSceneFolder,sticker;

    [SerializeField] private Button[] buttonToOn;
    [SerializeField] private GameObject[] images;
    [SerializeField] private ParticleSystem[] _particles;

    [SerializeField] private ParticleSystem _coinsParticleSystem;
    [SerializeField] private AudioClip clip;
    [SerializeField] private AudioSource _source;
    [SerializeField] private GameObject valueOfCompletedLevels;
    [SerializeField] private GameObject finishPanel, coinScript;
    private bool isImageOn = false;
    private int Value;
    public UnityEvent _event = new();

    private void Awake()
    {
        _event.AddListener(() =>
        {
            var SceneValue = $"{SceneManager.GetActiveScene().name}_Value";
            
            Value = PlayerPrefs.GetInt(SceneValue);
            
            PlayerPrefs.SetInt(SceneValue, Value += 1);
            print(Value);
        });
        
    }

    private void FixedUpdate()
    {
        
        if (Value>= 25)
        {
            Destroy(hints);
            //hintImage.SetActive(false);
            Bar.SetActive(false);
           if (isImageOn == false) StartCoroutine(Image());
           //effectOnEnd1.SetActive(true);
            //effectOnEnd2.SetActive(true);
        }
        
    }

    private IEnumerator Image()
    {
        foreach (var particle in _particles)
        {
            particle.gameObject.SetActive(true);
        }
        int puzzleLevelIndex = PlayerPrefs.GetInt("CompletedPuzzleLevels");
        PlayerPrefs.SetInt("CompletedPuzzleLevels",puzzleLevelIndex + 1);
        var PuzzleLevelValue = $"{SceneUtility.GetBuildIndexByScenePath($"Assets/Scenes/{SceneManager.GetActiveScene().name}.unity")}".ToString();
        PlayerPrefs.SetInt(PuzzleLevelValue,1);
        int random = Random.Range(0, images.Length);
        isImageOn = true;
        itemsOnSceneFolder.SetActive(false);
        sticker.SetActive(true);
        yield return new WaitForSeconds(2f);
        finishPanel.SetActive(true);
        
        yield return new WaitForSeconds(2.7f);
        _coinsParticleSystem.gameObject.SetActive(true);
        coinScript.SetActive(true);
        _source.PlayOneShot(clip);
        yield return new WaitForSeconds(4f);
        finishPanel.SetActive(false);
        Points.isTheGameEnd = true;
        valueOfCompletedLevels.SetActive(true);
        foreach (var button in buttonToOn)
        {
            button.gameObject.SetActive(true);
        }
    }
    
}
