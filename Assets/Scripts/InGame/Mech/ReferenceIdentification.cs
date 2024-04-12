using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class ReferenceIdentification : MonoBehaviour
{
   [SerializeField] private PointDetect _imageObject;
   [SerializeField] private PointDetect2 _secondImageObject;
   [SerializeField] private GameObject _nonRightCircle,CanvasParent;
   private Vector3 pointPosition;
   public UnityEvent ReferenceTouched = new();
   private float _timer = 2f;
   private void Awake()
   {

      if (SceneManager.GetActiveScene().name == "Level_1")
      {
         
         _imageObject.GetComponent<PointDetect>();
      }
      
      _imageObject.ImageClicked.AddListener(() =>
      {
         pointPosition = _imageObject.PointPosition();
         GameObject Non = Instantiate(_nonRightCircle, pointPosition, quaternion.identity);
         Non.transform.SetParent(CanvasParent.transform,false);
         
         
         
         
      });
      
      _secondImageObject.ImageClicked.AddListener(() =>
      {
         pointPosition = _secondImageObject.PointPosition();
         
         GameObject Non = Instantiate(_nonRightCircle, pointPosition, quaternion.identity);
         Non.transform.SetParent(CanvasParent.transform,false);
         
         
         
         
      });
      
   }

   private void Update()
   {
      _timer -= Time.deltaTime;
      if (_timer < 0)
      {
         
      }
   }
}
