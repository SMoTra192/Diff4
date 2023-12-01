using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class RandomEnableImages : MonoBehaviour
{
    [SerializeField] private GameObject Folder;
    public static bool isImageSet = false;
    private int index;
    private void Awake()
    {
        int Childs = Folder.transform.childCount;
        for (int i = 0; i < Childs; i++)
        {
            Transform child = Folder.transform.GetChild(i);
            child.gameObject.SetActive(false);
        }

        int randomchild = Random.Range(0, Childs);
        Transform rndChild = Folder.transform.GetChild(randomchild);
        rndChild.gameObject.SetActive(true);
    }

    private void Update()
    {
        //if (isImageSet == true)
        {
           // RandomEnable();
           // isImageSet = false;
        }
    }

    private void RandomEnable()
    {
        int Childs = Folder.transform.childCount;
        if (Childs > 0)
        {
            int randomchild = Random.Range(0, Childs);
            Transform rndChild = Folder.transform.GetChild(randomchild);
            
            rndChild.gameObject.SetActive(true);
        }
        else
        {
            return;
        }
    }
}
