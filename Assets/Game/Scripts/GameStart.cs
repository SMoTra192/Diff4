using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using Random = System.Random;

public class GameStart : MonoBehaviour
{
    [SerializeField] private GameObject _poolOfItemsParent, _poolSpaceParent, _inGameScenePrefabParent;
    private string objName;
    public UnityEvent Started = new();
    private GameObject child;
    private bool isStarted = false;

    private void Awake()
    {
        int childcount = _poolOfItemsParent.transform.childCount;
        int childcoun2 = _poolOfItemsParent.transform.childCount;
        for (int i = 0; i < childcount; ++i)
        {
            
            objName = PlayerPrefs.GetString($"Level_{SceneIndex()}_Name_{i}");

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
            objName = PlayerPrefs.GetString($"PuzzleLevel_{SceneIndex()}_InScenePrefab_{i+1}");
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
    

    
    public int SceneIndex()
    {
        string level = SceneManager.GetActiveScene().name;
        string Level;
        int index;
        Level = level.Length >= 14 ? level.Substring(level.Length - 2) : level.Substring(level.Length - 1);


        index = int.Parse(Level);
        return index;
    }

    
}
