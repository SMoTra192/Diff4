using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class PanelFinish : MonoBehaviour
{
   [SerializeField] private AudioClip _clip;
   [SerializeField] private AudioSource _source;
   [SerializeField] private GameObject _gameObject;
   [SerializeField] private GameObject _nextButton;
   
   private float elasped;
   private float TimeToNextMove = 3f;
   private bool isPlayed;
   private int index;
   private int completedLevelIndex;
   private void Start()
   {
      isPlayed = false;
      index = SceneIndex();
       completedLevelIndex = PlayerPrefs.GetInt("CompletedLevels");
       if (completedLevelIndex < index) PlayerPrefs.SetInt("CompletedLevels",completedLevelIndex + 1);
       
   }

   

   private void Update()
   {
      elasped += Time.deltaTime;
      //print(index);
      //print(completedLevelIndex);
      if (elasped >= TimeToNextMove / 2 && isPlayed == false)
      {
         if (completedLevelIndex < index)
         {
            _gameObject.SetActive(true);
            _source.PlayOneShot(_clip);
            isPlayed = true;
         }
         
      }


      if (elasped >= TimeToNextMove)
      {
         _nextButton.gameObject.SetActive(true);
         gameObject.SetActive(false);
      }
      
   }

   
   int SceneIndex()
   {
      string level = SceneManager.GetActiveScene().name;
      string Level;
      if (level.Length >= 8) Level = level.Substring(level.Length - 2);
      else
      {
         Level = level.Substring(level.Length - 1);
      }

      
      index = int.Parse(Level);
      return index;
   }

  
}
