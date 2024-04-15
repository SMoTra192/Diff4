using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class Tutorial : MonoBehaviour , IPointerDownHandler
{
    
    [SerializeField] private GameObject tutorialObj,tutorialObj2,obj3;

    private bool isObj2Touched = false;
    void Start()
    {
        if (PlayerPrefs.GetInt("Tutorial") >= 1)
        {
            gameObject.SetActive(false);
        }
        FindObjectOfType<ReferenceIdentification>().ReferenceTouched.AddListener(() =>
        {
           if(gameObject.activeInHierarchy) StartCoroutine(wait());
        });
        
        FindObjectOfType<ReferenceIdentification>().ReferenceTouched.AddListener(() =>
        {
            if (obj3.activeInHierarchy)
            {
                StartCoroutine(wait2());
            }
        });
        
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetTouch(0).phase == TouchPhase.Ended ) tutorialObj2.SetActive(false);
        if (Input.touchCount == 2) tutorialObj2.SetActive(false);
    }


    public void OnPointerDown(PointerEventData eventData)
    {
        tutorialObj2.SetActive(false);
    }

    private IEnumerator wait()
    {
        tutorialObj.SetActive(false);
        yield return new WaitForSeconds(1.5f);
        if (PlayerPrefs.GetInt("Tutorial") == 0)
        {
            PlayerPrefs.SetInt("Tutorial",1);
            tutorialObj.SetActive(false);
            obj3.SetActive(true);
        }
    }
    private IEnumerator wait2()
    {
        obj3.SetActive(false);
        yield return new WaitForSeconds(1.5f);
        tutorialObj2.SetActive(true);
    }
}
