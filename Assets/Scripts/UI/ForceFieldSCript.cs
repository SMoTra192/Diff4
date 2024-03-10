using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.EventSystems;

public class ForceFieldSCript : MonoBehaviour 
{
   private int winningPoints;
   [SerializeField] private GameObject _forceField;
   [SerializeField] private ParticleSystem _particleSystem;
   [SerializeField] private Camera _camera;
   
   private Vector2 pointPosition;
   private void Awake()
   {
       winningPoints = 0;
      FindObjectOfType<ReferenceIdentification>().ReferenceTouched.AddListener(() =>
      { 
          if(winningPoints>0)_forceField.transform.GetChild(winningPoints - 1).gameObject.SetActive(false);
        // _particleSystem.Clear(withChildren:true);
        // _particleSystem.Stop(withChildren:true,ParticleSystemStopBehavior.StopEmittingAndClear);
         winningPoints++;
         
         _forceField.transform.GetChild(winningPoints - 1).gameObject.SetActive(true);
         pointPosition = _camera.ScreenToWorldPoint(Input.mousePosition);
         //print(pointPosition);
         
        _particleSystem.transform.position = pointPosition;
       // print(_particleSystem.transform.position);
        _particleSystem.Play();
        //FindObjectOfType<CheckDetection>().checkDetect();
        //_particleSystem.
         //_particleSystem.transform.SetParent(_parentCanvas.transform);
         //_particleSystem.transform.localScale = new Vector3(1, 1, 1);
         //StartCoroutine(timer());

      });
   }

   
   IEnumerator timer()
   {
      yield return new WaitForSeconds(2f);
      _forceField.transform.GetChild(winningPoints).gameObject.SetActive(false);
   }
}
