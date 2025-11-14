using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class HintMech : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _AdText;
    [SerializeField] private ReferenceRightIcons _referenceRightIcons;
    [SerializeField] private GameObject AdImage,ADForHint;
    public UnityEvent hintPressed = new();

    private void Awake()
    {
        _referenceRightIcons.GetComponent<ReferenceRightIcons>();
    }

    private void Update()
    {
    
         _AdText.text = "Ad";
         AdImage.SetActive(true); 
    }

    public void Click()
    {
            
                _referenceRightIcons.CheckHint();
                _referenceRightIcons.CheckHint2();
                hintPressed.Invoke();
    }
}
