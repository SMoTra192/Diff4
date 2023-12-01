using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;




public class ReferenceObject : MonoBehaviour 
{
    private int index;
    private bool isTouched = false;
    private float _timer;
    [SerializeField]private Button _button;
    
    private void Awake()
    { ;
        
        _button.onClick.AddListener(() =>
        {
            index = gameObject.transform.GetSiblingIndex();
            ReferenceRightIcons.index = index;
            if (!isTouched && Input.touchCount != 2) FindObjectOfType<ReferenceIdentification>().ReferenceTouched.Invoke();
            if(Input.touchCount == 1) isTouched = false;
            
        });
    }
    
    private void Update()
    {
        if (Input.touchCount == 0)
        {
            _timer = 0;
            isTouched = false;
        }
        
        if (Input.touchCount >= 1)
        {
            Touch _touch = Input.GetTouch(0);
            Touch _touch2 = default;
            if (_touch.phase == TouchPhase.Moved)
            {
                _timer += Time.deltaTime;
            }
            if (_touch.phase == TouchPhase.Moved && _timer > 0.15f)
            {
                isTouched = true;
            }
            if(Input.touchCount >=2)
            {
                _touch2 = Input.GetTouch(1);
            }

            if (_touch.phase == TouchPhase.Moved && Input.touchCount == 2)
            {
                //print("hello");
                isTouched = true;  
            }
            if (_touch2.phase == TouchPhase.Moved && Input.touchCount == 2)
            {
                //print("hello");
                isTouched = true;  
            }

            
            if (_touch.phase == TouchPhase.Ended)
            {
                isTouched = false;
            }
            
            if (_touch.phase == TouchPhase.Stationary && Input.touchCount == 2)
                
            {
                //print("IsTouched");
                isTouched = true;  
            }

            
            if(_touch.phase == TouchPhase.Stationary) print("Star");
        }
        
    }
}
