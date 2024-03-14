using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.Events;

public class FirstTimeTutorialPuzzles : MonoBehaviour
{
   [SerializeField] private GameObject _tutorialObj,_tutorialObj2,_whiteBackGround;
   [SerializeField] private GameObject pos_char, backgroundFolder;
   [SerializeField] private GameObject _cloudsOpen,_cloudsOpenAnimation;
   private RectTransform _rectGameobject;
   private RectTransform gm,gm2,gm3,gm4;

   public UnityEvent ItemsSpawned = new();
   public UnityEvent TimedForClouds = new UnityEvent();
   private void Awake()
   {
      StartCoroutine(await());

      TimedForClouds.AddListener(()=>
      {
         StartCoroutine(timeAwaitClouds());
      });
   }












   private IEnumerator await()
   {
      Vector3 position;
      if(PlayerPrefs.GetInt("PuzzleLevelLoad") == 0) PlayerPrefs.SetInt("PuzzleLevelLoad", 1);
        
      yield return Addressables.InstantiateAsync($"Assets/GameImages/Puzzles/{PlayerPrefs.GetInt("PuzzleLevelLoad")}/CHARACTER.prefab",parent:gameObject.transform,true);
      GameObject _gm = FindObjectOfType<Char>().gameObject;
      position = pos_char.transform.position;
      _gm.transform.position = position;
      gm = _gm.GetComponent<RectTransform>();
      gm.transform.localScale = new Vector3(1, 1, 1);
      gm.transform.SetSiblingIndex(0);
      
      yield return Addressables.InstantiateAsync($"Assets/GameImages/Puzzles/{PlayerPrefs.GetInt("PuzzleLevelLoad")}/Pole_Image.prefab",parent:backgroundFolder.transform,true);
      GameObject _gm2 = FindObjectOfType<Pole_image>().gameObject;
      position = pos_char.transform.position + new Vector3(0,0.3f,0);
      _gm2.transform.position = position;
      gm2 = _gm2.GetComponent<RectTransform>();
      gm2.transform.localScale = new Vector3(1, 1, 1);
      gm2.transform.SetSiblingIndex(1);
      
      yield return Addressables.InstantiateAsync($"Assets/GameImages/Puzzles/{PlayerPrefs.GetInt("PuzzleLevelLoad")}/CHARACTER_Finish.prefab",parent:gameObject.transform,true);
      GameObject _gm3 = FindObjectOfType<char_finish>().gameObject;
      position = pos_char.transform.position;
      _gm3.transform.position = position;
      gm3 = _gm3.GetComponent<RectTransform>();     
      gm3.transform.localScale = new Vector3(1, 1, 1);
      gm3.transform.SetSiblingIndex(0);

      yield return Addressables.InstantiateAsync($"Assets/GameImages/Puzzles/{PlayerPrefs.GetInt("PuzzleLevelLoad")}/Imag_Stiker.prefab",parent:backgroundFolder.transform,true);
      GameObject _gm4 = FindObjectOfType<Image_stiker>().gameObject;
      position = pos_char.transform.position + new Vector3(0,0.3f,0);
      _gm4.transform.position = position;
      gm4 = _gm4.GetComponent<RectTransform>();
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
      TimedForClouds.Invoke();
   }
   private IEnumerator timeAwaitClouds()
   {
      yield return new WaitForSeconds(0.3f);
_cloudsOpenAnimation.SetActive(true);
    _cloudsOpen.SetActive(false);
   }
}
