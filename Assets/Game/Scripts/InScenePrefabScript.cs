using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InScenePrefabScript : MonoBehaviour
{
    private int index;
    public UnityEvent isTouched = new();
    private void OnTriggerEnter2D(Collider2D col)
    {
        
        index = gameObject.transform.GetSiblingIndex() ;
        isTouched.Invoke();

    }

    public int Index()
    {
        
        return index;
    }
}
