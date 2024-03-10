using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class TheGameEnd : MonoBehaviour
{
    [SerializeField] private GameObject hints, Bar;
    [SerializeField] private GameObject sticker, _tutorialObj3;
        
    [SerializeField] private GameObject itemsOnSceneFolder;
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
        FindObjectOfType<FirstTimeTutorialPuzzles>().ItemsSpawned.AddListener(() =>
        {
            _tutorialObj3 = FindObjectOfType<char_finish>().gameObject;
            sticker = FindObjectOfType<Image_stiker>().gameObject;
            _tutorialObj3.SetActive(false);
            sticker.SetActive(false);
        });
            
            
        FindObjectOfType<GameStart>().Started.AddListener(() =>
        {
            itemsOnSceneFolder = FindObjectOfType<PlaygroundScript>().gameObject;
            int index;
            index = itemsOnSceneFolder.transform.childCount;
            itemsOnSceneFolder = itemsOnSceneFolder.transform.GetChild(index - 2).gameObject;
        });
        _event.AddListener(() =>
        {
            var SceneValue = $"PuzzleLevel_{PlayerPrefs.GetInt("PuzzleLevelLoad")}_Value";
            
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
        itemsOnSceneFolder.transform.GetChild(0).gameObject.SetActive(false);
        sticker.SetActive(true);
        yield return new WaitForSeconds(1f);
        if (PlayerPrefs.GetInt($"PuzzlesTutorial_{PlayerPrefs.GetInt("PuzzleLevelLoad")}") == 1)
        {
            _tutorialObj3.SetActive(true);
        }
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
