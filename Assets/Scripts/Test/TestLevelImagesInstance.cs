using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.AddressableAssets;

public class TestLevelImagesInstance : MonoBehaviour
{
    [SerializeField] private GameObject firstimage1, secondimage2;
    private AssetReferenceGameObject _gm;
    private RectTransform _gameObject;
    public UnityEvent onSpot = new();
    void Start()
    {
        int NowLevel = PlayerPrefs.GetInt("NowLevel");
        print(NowLevel);
        StartCoroutine(instASync());
        /*_gameObject = Resources.Load<RectTransform>($"Levels/{NowLevel}/Image1");
        RectTransform obj = Instantiate(_gameObject, transform.position, quaternion.identity);
        obj.transform.SetParent(firstimage1.gameObject.transform);
        obj.transform.localScale = new Vector3(1, 1, 1);
        obj.anchoredPosition = new Vector2(0, 0);
        _gameObject = Resources.Load<RectTransform>($"Levels/{NowLevel}/Image2");
        obj = Instantiate(_gameObject, transform.position, quaternion.identity);
        obj.transform.SetParent(secondimage2.gameObject.transform);
        obj.transform.localScale = new Vector3(1, 1, 1);
        obj.anchoredPosition = new Vector2(0, 0);
        */
        
        
    }

    private IEnumerator instASync()
    {
        yield return Addressables.InstantiateAsync($"GameImages/{1}/Image1.prefab",parent:firstimage1.transform,true);
        GameObject gm = FindObjectOfType<FirstPicture>().gameObject;
        gm.transform.localScale = new Vector3(1, 1, 1);
        RectTransform rect = gm.GetComponent<RectTransform>();
        rect.anchoredPosition = new Vector2(0, 0);
        yield return Addressables.InstantiateAsync($"GameImages/{1}/Image2.prefab",parent:secondimage2.transform,true);
        gm = FindObjectOfType<SecondPicture>().gameObject;
        gm.transform.localScale = new Vector3(1, 1, 1);
        rect = gm.GetComponent<RectTransform>();
        rect.anchoredPosition = new Vector2(0, 0);
        onSpot.Invoke();
    }
}