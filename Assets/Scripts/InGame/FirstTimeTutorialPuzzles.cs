using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Events;

public class FirstTimeTutorialPuzzles : MonoBehaviour
{
   [SerializeField] private GameObject _tutorialObj,_tutorialObj2,_whiteBackGround;
   [SerializeField] private GameObject pos_char, backgroundFolder;
   private RectTransform _rectGameobject;
   private RectTransform gm,gm2,gm3,gm4;

   public UnityEvent ItemsSpawned = new();
   private void Awake()
   {
      Vector3 position;
      if(PlayerPrefs.GetInt("PuzzleLevelLoad") == 0) PlayerPrefs.SetInt("PuzzleLevelLoad", 1);
        
      _rectGameobject = Resources.Load<RectTransform>($"Levels/Puzzles/{PlayerPrefs.GetInt("PuzzleLevelLoad")}/CHARACTER");
      position = pos_char.transform.position;
      gm = Instantiate(_rectGameobject, position, quaternion.identity);
      gm.transform.SetParent(gameObject.transform);
      gm.transform.localScale = new Vector3(1, 1, 1);
      gm.transform.SetSiblingIndex(0);
      
      _rectGameobject = Resources.Load<RectTransform>($"Levels/Puzzles/{PlayerPrefs.GetInt("PuzzleLevelLoad")}/pole_image");
      position = pos_char.transform.position + new Vector3(0,0.3f,0);
      gm2 = Instantiate(_rectGameobject, position, quaternion.identity);
      gm2.transform.SetParent(backgroundFolder.gameObject.transform);
      gm2.transform.localScale = new Vector3(1, 1, 1);
      gm2.transform.SetSiblingIndex(1);
      
      _rectGameobject = Resources.Load<RectTransform>($"Levels/Puzzles/{PlayerPrefs.GetInt("PuzzleLevelLoad")}/CHARACTER_Finish");
      position = pos_char.transform.position;
      gm3 = Instantiate(_rectGameobject, position, quaternion.identity);
      gm3.transform.SetParent(gameObject.transform);
      gm3.transform.localScale = new Vector3(1, 1, 1);
      gm3.transform.SetSiblingIndex(0);

      _rectGameobject = Resources.Load<RectTransform>($"Levels/Puzzles/{PlayerPrefs.GetInt("PuzzleLevelLoad")}/Imag_Stiker");
      position = pos_char.transform.position + new Vector3(0,0.3f,0);
      gm4 = Instantiate(_rectGameobject, position, quaternion.identity);
      gm4.transform.SetParent(backgroundFolder.gameObject.transform);
      gm4.transform.localScale = new Vector3(1, 1, 1);
      gm4.transform.SetSiblingIndex(2);
      
      _tutorialObj = FindObjectOfType<Char>().gameObject;
      _tutorialObj.SetActive(false);
      _tutorialObj2 = FindObjectOfType<Pole_image>().gameObject;
      _tutorialObj2.SetActive(false);
      ItemsSpawned.Invoke();
      
      
         print(PlayerPrefs.GetInt($"PuzzlesTutorial_{PlayerPrefs.GetInt("PuzzleLevelLoad")}"));
         if (PlayerPrefs.GetInt($"PuzzlesTutorial_{PlayerPrefs.GetInt("PuzzleLevelLoad")}") == 0)
         {
            _tutorialObj.SetActive(true);
            _tutorialObj2.SetActive(true);
            _whiteBackGround.SetActive(true);
            PlayerPrefs.SetInt($"PuzzlesTutorial_{PlayerPrefs.GetInt("PuzzleLevelLoad")}", 1);
         }

         
      
      
   }
}
