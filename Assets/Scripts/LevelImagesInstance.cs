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
        StartCoroutine(instASync());
    }
    private IEnumerator instASync()
    {
        _clouds[0].SetActive(true);
        GameObject instance1 = null;
        Debug.Log(NowLevel);
        ResourceRequest Object = Resources.LoadAsync<GameObject>($"GameImages/NowLevels/{NowLevel}/Image1");
        yield return Object;
        
            if(Object.asset == null)
        {
            Debug.Log("NotCompleted");
            Debug.LogError("FirstPicture component not found");
            Application.Quit();
        }

        else

        {
            instance1 = Instantiate(Object.asset as GameObject, firstimage1.transform);
            
        }
        
        FirstPicture firstPicture = instance1.GetComponent<FirstPicture>();
        SetupImageTransform(firstPicture.gameObject);
        //gm.transform.localScale = new Vector3(1, 1, 1);
        //RectTransform rect = gm.GetComponent<RectTransform>();
        //rect.anchoredPosition = new Vector2(0, 0);

        ResourceRequest Object2 = Resources.LoadAsync<GameObject>($"GameImages/NowLevels/{NowLevel}/Image2");
        yield return Object2;
        GameObject instance2 = null;

        if(Object2.asset == null) 
        {
            Debug.Log("NotCompleted");
            Debug.LogError("SecondPicture component not found");
            Application.Quit();
        }

        else

        {
            instance2 = Instantiate(Object2.asset as GameObject, secondimage2.transform);
        }

        SecondPicture secondPicture = instance2.GetComponent<SecondPicture>();
        SetupImageTransform(secondPicture.gameObject);
        _clouds[1].SetActive(true);
        _clouds[0].SetActive(false);
        
        onSpot.Invoke();
    }
    
    private void SetupImageTransform(GameObject gm)
    {
        if(gm == null) return;
        
        gm.transform.localScale = new Vector3(1, 1, 1);
        RectTransform rect = gm.GetComponent<RectTransform>();
        if(rect != null)
        {
            rect.anchoredPosition = new Vector2(0, 0);
        }
    }
}
