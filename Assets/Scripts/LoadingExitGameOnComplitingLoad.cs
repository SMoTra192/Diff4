using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadingExitGameOnComplitingLoad : MonoBehaviour
{
    private Button _button;

    
    void Awake()
    {
       _button = GetComponent<Button>();
       _button.onClick.AddListener(()=>
       {
Application.Quit();
       }) ;
    }
}
