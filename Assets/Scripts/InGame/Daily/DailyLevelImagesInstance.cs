using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Events;

public class DailyLevelImagesInstance : MonoBehaviour
{
    [SerializeField] private GameObject firstimage1, secondimage2;
    private RectTransform _gameObject;
    public UnityEvent onSpot = new(), onSpotNext = new();

    void Start()
    {
        int NowLevel = PlayerPrefs.GetInt("DailyNowLevel");
        print(NowLevel);
        _gameObject = Resources.Load<RectTransform>($"Levels/DL_1/{NowLevel}/Image1");
        RectTransform obj = Instantiate(_gameObject, transform.position, quaternion.identity);
        obj.transform.SetParent(firstimage1.gameObject.transform);
        obj.transform.localScale = new Vector3(1, 1, 1);
        obj.anchoredPosition = new Vector2(0, 0);
        _gameObject = Resources.Load<RectTransform>($"Levels/DL_1/{NowLevel}/Image2");
        obj = Instantiate(_gameObject, transform.position, quaternion.identity);
        obj.transform.SetParent(secondimage2.gameObject.transform);
        obj.transform.localScale = new Vector3(1, 1, 1);
        obj.anchoredPosition = new Vector2(0, 0);

        onSpot.Invoke();

    }
}

