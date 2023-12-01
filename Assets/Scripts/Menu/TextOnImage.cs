    using System;
    using System.Collections;
using System.Collections.Generic;
    using TMPro;
    using UnityEngine;
    using UnityEngine.SceneManagement;

    public class TextOnImage : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private GameObject parent;

    private void Update()
    {
        _text.text = $"Level {parent.transform.GetSiblingIndex() + 1}";
        //print(_text.text);
    }
    
}
