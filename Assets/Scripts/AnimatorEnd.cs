using System;
using System.Collections;
using System.Collections.Generic;
using Coffee.UIEffects;
using UnityEngine;

public class AnimatorEnd : MonoBehaviour
{
   private UIShiny _ui;

   private void Awake()
   {
      _ui = GetComponent<UIShiny>();
      
   }

   private void OnEnable()
   {
      _ui.Play();
   }
}
