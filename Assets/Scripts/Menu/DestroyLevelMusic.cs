using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyLevelMusic : MonoBehaviour
{
    [SerializeField] private string tag;
    private void Start()
    {
        GameObject obj = GameObject.FindWithTag(tag);
        if (obj != null) Destroy(obj);
        
    }
}
