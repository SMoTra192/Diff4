using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using Random = UnityEngine.Random;

public class Points : MonoBehaviour
{
   private int points, countToAdd = 60, i;
   public static string keyPoints;
   public static bool isTheGameEnd = false;
   private void Awake()
   {
      
      Vibration.Init();
      keyPoints = "Points";
   }

   private void Update()
   {
      points = PlayerPrefs.GetInt(keyPoints);
      if (isTheGameEnd == true && i < countToAdd)
      {
         StartCoroutine(addPoints());
         int VibrationSet = PlayerPrefs.GetInt("VibrationEnabled");
         if(VibrationSet == 0 && i < 2) 
            Vibration.VibrateAndroid(35);
         i++;
      }

      if (isTheGameEnd == true && i == countToAdd) isTheGameEnd = false;
   }

   private IEnumerator addPoints()
   {
      
      PlayerPrefs.SetInt(keyPoints, points + Random.Range(5,8));
      
      yield return new WaitForSeconds(0.1f);
   }

}
