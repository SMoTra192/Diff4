using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hintimage : MonoBehaviour
{
    private Button _button;
    void Start()
    {
        _button = GetComponent<Button>();
        _button.onClick.AddListener(() =>
        {
            gameObject.SetActive(false);
        });
    }

    
}
