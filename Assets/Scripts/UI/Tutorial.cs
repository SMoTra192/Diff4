using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Tutorial : MonoBehaviour , IPointerDownHandler
{
    
    [SerializeField] private GameObject tutorialObj,obj2,tutorialObj2;
    [SerializeField] private GameObject panelFinishObj;
    void Start()
    {
        if (PlayerPrefs.GetInt("Tutorial") >= 1)
        {
            gameObject.SetActive(false);
            if(panelFinishObj != null) panelFinishObj.SetActive(false);
        }
        FindObjectOfType<ReferenceIdentification>().ReferenceTouched.AddListener(() =>
        {
           if(gameObject.activeInHierarchy) StartCoroutine(wait());
        });
        FindObjectOfType<EntryPoint>().Tutorialed.AddListener(() =>
        {
            if(panelFinishObj != null) panelFinishObj.SetActive(true);
            PlayerPrefs.SetInt("Tutorial",2);
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
        obj2.SetActive(false);
        yield return new WaitForSeconds(1.5f);
        if (PlayerPrefs.GetInt("Tutorial") == 0)
        {
            PlayerPrefs.SetInt("Tutorial",1);
            tutorialObj.SetActive(false);
            obj2.SetActive(false);
            tutorialObj2.SetActive(true);
                
        }
    }
    
}
