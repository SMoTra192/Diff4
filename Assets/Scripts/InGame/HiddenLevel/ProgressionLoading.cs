using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class ProgressionLoading : MonoBehaviour
{
    private RectTransform _rectGameobject;
    private RectTransform gm;
    [SerializeField] private GameObject _uiParent;
    public UnityEvent Created = new();
    
    
    
    [SerializeField] private GameObject _hintPrefab;
    private GameObject[] objFolder;
    private GameObject _content;
    [SerializeField] private Button _hintButton;
    private int _tries;
    void Awake()
    {
        _tries = 0;
        _hintButton.onClick.AddListener(() =>
        {
            HintClick();
        });
        
        
        
        
        PlayerPrefs.SetInt($"LoadedLevel{PlayerPrefs.GetInt("CompletedHiddenLevels")}",1);
        
        _rectGameobject = Resources.Load<RectTransform>($"Levels/Hidden/{PlayerPrefs.GetInt("CompletedHiddenLevels")}/Scroll");
        //PlayerPrefs.GetInt("HiddenLevelLoad")
        gm = Instantiate(_rectGameobject, _uiParent.transform.position, quaternion.identity);
        gm.transform.SetParent(_uiParent.gameObject.transform);
        gm.sizeDelta = new Vector2(0, 0);
        gm.transform.localScale = new Vector3(1, 1, 1);
        gm.transform.SetSiblingIndex(0);
        
        _content = GameObject.Find("Scroll(Clone)").transform.GetChild(0).gameObject;
        print(_content.name);
        objFolder = new GameObject[3];
        for (int i = 0; i < 3; i++)
        {
            objFolder[i] = (_content.transform.GetChild(1).gameObject.transform.GetChild(i).gameObject); //.gameObject.transform.GetChild(1).gameObject.transform.GetChild(i).gameObject);
            print(objFolder[i].name);
        }

        StartCoroutine(InvokeCoroutine());
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
    IEnumerator InvokeCoroutine()
    {
        yield return null;
            Created.Invoke();
    }
}
