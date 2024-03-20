using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using System.Runtime.InteropServices;

public class LevelImagesInstance : MonoBehaviour
{
    [SerializeField] private GameObject firstimage1, secondimage2;
    private RectTransform _gameObject;
    public UnityEvent onSpot = new();
    private int NowLevel;
    
    [SerializeField] private GameObject[] _clouds;
     void Start()
    {
        NowLevel = PlayerPrefs.GetInt("NowLevel");
        //print(NowLevel);
        StartCoroutine(instASync());
    }
    private IEnumerator instASync()
    {
        _clouds[0].SetActive(true);
        AsyncOperationHandle<GameObject> handle = Addressables.LoadAssetAsync<GameObject>($"Assets/GameImages/NowLevels/{NowLevel}/Image1.prefab");
        
        if(handle.Status == AsyncOperationStatus.Failed) 

        {
            Debug.Log("NotCompleted");
            Application.Quit();
        }

        else

        {
            //Debug.Log("Completed");
        }
        yield return Addressables.InstantiateAsync($"Assets/GameImages/NowLevels/{NowLevel}/Image1.prefab",parent:firstimage1.transform,true);

        GameObject gm = FindObjectOfType<FirstPicture>().gameObject;
        gm.transform.localScale = new Vector3(1, 1, 1);
        RectTransform rect = gm.GetComponent<RectTransform>();
        rect.anchoredPosition = new Vector2(0, 0);

        AsyncOperationHandle<GameObject> handle2 = Addressables.LoadAssetAsync<GameObject>($"Assets/GameImages/NowLevels/{NowLevel}/Image2.prefab");
        
        if(handle2.Status == AsyncOperationStatus.Failed) 
        {
            Debug.Log("NotCompleted");
            Application.Quit();
        }

        else

        {
            //Debug.Log("Completed");
        }

        yield return Addressables.InstantiateAsync($"Assets/GameImages/NowLevels/{NowLevel}/Image2.prefab",parent:secondimage2.transform,true);
        gm = FindObjectOfType<SecondPicture>().gameObject;
        gm.transform.localScale = new Vector3(1, 1, 1);
        rect = gm.GetComponent<RectTransform>();
        rect.anchoredPosition = new Vector2(0, 0);
        //_animator.Play();
        _clouds[1].SetActive(true);
        _clouds[0].SetActive(false);
        
        onSpot.Invoke();
    }
    
}
