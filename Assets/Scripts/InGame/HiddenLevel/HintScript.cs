using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class HintScript : MonoBehaviour
{
    [SerializeField] private GameObject _hintPrefab;
     private List<GameObject> objFolder;
     [SerializeField] private ProgressionLoading _progressionLoading;
    
     private GameObject _content;
    private Button _thisButton;
    private int _tries;
    private void Start()
    {
        _progressionLoading.GetComponent<ProgressionLoading>();
        _tries = 0;
        _thisButton = GetComponent<Button>();
        _thisButton.onClick.AddListener(() =>
        {
            HintClick();
        });
        _progressionLoading.Created.AddListener(() =>
        {
            print("Created");
            _content = GameObject.Find("Content");
            
            for (int i = 0; i < 3; i++)
            {
                objFolder.Add(GameObject.Find($"Obj{i+1}_folder"));
                print(objFolder[i].name);
            }
        });
    }

    public void HintClick()
    {
        int Rnd = Random.Range(0, 3);
        int Rnd2 = Random.Range(0, 5);
        Vector3 pos = objFolder[Rnd].transform.GetChild(Rnd2).transform.GetChild(0).transform.position;
        GameObject hint = Instantiate(_hintPrefab, pos, quaternion.identity);
        
        if (objFolder[Rnd].transform.GetChild(Rnd2).transform.GetChild(0).gameObject.activeInHierarchy && objFolder[Rnd].transform.GetChild(Rnd2).transform.childCount < 3)
        {
            hint.transform.SetParent(objFolder[Rnd].transform.GetChild(Rnd2));
            hint.transform.localScale = new Vector3(1, 1, 1);
            hint.transform.GetChild(0).gameObject.SetActive(true);
            _content.transform.position = new Vector3(-objFolder[Rnd].transform.GetChild(Rnd2).transform.GetChild(0).transform.position.x + 0.3f,_content.transform.position.y,_content.transform.position.z);
        }
        else
        {
            Destroy(hint);
            _tries += 1;
            if(_tries<= 1000)HintClick();
        }
        
        
    }
}
