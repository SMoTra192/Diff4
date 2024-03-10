using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialObj : MonoBehaviour
{

    private GameObject tutorialObj;

    private void Start()
    {
        tutorialObj = this.gameObject;
        if (PlayerPrefs.GetInt("TutorialHiddenLevel") == 0)
        {
            StartCoroutine(iwait());
            PlayerPrefs.SetInt("TutorialHiddenLevel",1);
        }
        else
        {
            tutorialObj.SetActive(false);
        }
    }

    private IEnumerator iwait()
    {
        print("Tutorialed");
        yield return new WaitForSeconds(4f);
        tutorialObj.SetActive(false);

    }
    
}
