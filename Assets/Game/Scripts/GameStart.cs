using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using Random = System.Random;

public class GameStart : MonoBehaviour
{
    private GameObject _poolOfItemsParent, _poolSpaceParent, _inGameScenePrefabParent;
    private RectTransform rct;
        [SerializeField] private GameObject _playGroung,_playgroung2;
        
    private string objName;
    public UnityEvent Started = new();
    private GameObject child;
    private bool isStarted = false;
    private RectTransform _rectGameobject;

    private void Awake()
    {
        StartCoroutine(await());

    }
    
    private IEnumerator await()
    {

        Vector3 position;
        if(PlayerPrefs.GetInt("PuzzleLevelLoad") == 0) PlayerPrefs.SetInt("PuzzleLevelLoad", 1);
        

        yield return Addressables.InstantiateAsync($"Assets/GameImages/Puzzles/{PlayerPrefs.GetInt("PuzzleLevelLoad")}/TheGameScene.prefab",parent:_playGroung.gameObject.transform,true);
        position = _playGroung.transform.position;//+ new Vector3(0, 0.28f, 0);
        GameObject RCT = FindObjectOfType<TheGameSceneScript>().gameObject;
        rct = RCT.GetComponent<RectTransform>();
        rct.sizeDelta = new Vector2(0, 0);
        rct.transform.localScale = new Vector3(1, 1, 1);
        rct.anchoredPosition = new Vector2(0,0); 
        _inGameScenePrefabParent = rct.gameObject;
        
        
    
        yield return Addressables.InstantiateAsync($"Assets/GameImages/Puzzles/{PlayerPrefs.GetInt("PuzzleLevelLoad")}/Pool.prefab",parent:_playgroung2.gameObject.transform,true);
        GameObject RCT2 = FindObjectOfType<PoolScriptObject>().gameObject;
        rct = RCT2.GetComponent<RectTransform>();
       rct.sizeDelta = new Vector2(0, 0);
       rct.transform.localScale = new Vector3(1, 1, 1);



        _poolOfItemsParent = rct.gameObject;
        
        int childcount = _poolOfItemsParent.transform.GetChild(0).transform.childCount;
        int childcoun2 = _poolOfItemsParent.transform.GetChild(0).transform.childCount;
        _poolSpaceParent = _poolOfItemsParent.transform.GetChild(1).gameObject;


        _poolOfItemsParent = _poolOfItemsParent.transform.GetChild(0).gameObject;
        for (int i = 0; i < childcount; ++i)
        {
            
            objName = PlayerPrefs.GetString($"Level_{PlayerPrefs.GetInt("PuzzleLevelLoad")}_Name_{i}");

            for (int x = 0; x < childcoun2; x++)
            {
                Transform child2 = _poolOfItemsParent.transform.GetChild(x);
                if (child2.name == objName)
                {
                    child = child2.gameObject;

                    child.transform.SetParent(_poolSpaceParent.transform);
                    child.gameObject.SetActive(true);
                    childcoun2 -= 1;
                    
                }

            }


        }

        Transform childdd;
        int inScenePrefabChildCount = _inGameScenePrefabParent.transform.childCount;
        int inScenePrefabChildCount2 = _inGameScenePrefabParent.transform.childCount;
        for (int i = 0; i < inScenePrefabChildCount;i++)
        {
            objName = PlayerPrefs.GetString($"PuzzleLevel_{PlayerPrefs.GetInt("PuzzleLevelLoad")}_InScenePrefab_{i+1}");
            print(objName);
            if (objName.Contains($"InScenePrefab_{i+1}")) Destroy(GameObject.Find($"PoolPrefab_{i+1}"));
            if (objName.Contains($"InScenePrefab_{25}"))
            {
                print("hEY");
                childdd = _poolOfItemsParent.transform.GetChild(_poolOfItemsParent.transform.childCount - 1);
                print(childdd.name);
                childdd.transform.SetParent(_poolSpaceParent.transform);
            }
            
            for (int x = 0; x < inScenePrefabChildCount2; x++)
            {
                Transform child2 = _inGameScenePrefabParent.transform.GetChild(x);
                if (child2.name == objName)
                {
                    child = child2.gameObject;
                    child.gameObject.transform.GetChild(0).gameObject.SetActive(true);

                }
            }

        }
       Started.Invoke();
    }
}
