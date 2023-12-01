using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using Random = System.Random;

public class RectTransformLeft : MonoBehaviour
{
    private RectTransform _transform;
    [SerializeField] private Transform _poolSpaceParent, _poolOfItemsParent;
    private Vector2 _vector2;
    private int childCount, prevChildCount;
    public UnityEvent childOff = new();
    private int[] massive,poolOfItemsMassive, poolSpaceMassive;
    private string objName;
    private int starsAmount;
    private bool isChecked;

    private void Awake()
    {
        _transform = GetComponent<RectTransform>();
        
        
        for (int i = 0; i < gameObject.transform.childCount; i++)
        {
            gameObject.transform.GetChild(i).gameObject.SetActive(false);
        }
        //Random rnd = new Random(DateTime.Now.Millisecond);



        FindObjectOfType<GameStart>().Started.AddListener(() =>
        {
            
            if(_poolOfItemsParent.transform.childCount >= PlayerPrefs.GetInt("StarsAmount")) poolOfItemsMassive = new int[PlayerPrefs.GetInt("StarsAmount")];
            
            else
            {
                poolOfItemsMassive = new int[_poolOfItemsParent.transform.childCount];
            }
            //print(poolOfItemsMassive.Length);
            int childs = PlayerPrefs.GetInt("Childs");
            //print(childs);
            
            poolSpaceMassive = new int[_poolSpaceParent.transform.childCount];
            Random3();
            
            
            
            for (int j = 0; j < poolSpaceMassive.Length; j++)
            {
                if (_poolSpaceParent.transform.childCount != 0)
                {
                    Transform childd;
                    childd = _poolSpaceParent.transform.GetChild(j);
                    //print(poolSpaceMassive[j]);
                    childd.SetSiblingIndex(poolSpaceMassive[j]);
                }
            }



            
            
            int childCountPoolSpace = _poolSpaceParent.transform.childCount;
            int childCountPoolSpace2 = _poolSpaceParent.transform.childCount;
            int childCountPoolSpace3 = _poolSpaceParent.transform.childCount;
            
            
            massive = new int[_poolOfItemsParent.transform.childCount];
            
            Random();
            Random2();
            
            if ((poolOfItemsMassive.Length - PlayerPrefs.GetInt("Childs")) >= 0)
                
            {
                
                for (int i = 0;i<((poolOfItemsMassive.Length - PlayerPrefs.GetInt("Childs")));i++)
                {
                    //
                    _poolOfItemsParent.GetChild(massive[i]).gameObject.SetActive(true);
                    //_poolOfItemsParent.GetChild(poolOfItemsMassive[i]).SetSiblingIndex(i);
                }
                
                for (int i = 0;i<((poolOfItemsMassive.Length - PlayerPrefs.GetInt("Childs")));i++)
                {
                    //print(poolOfItemsMassive[i]);
                    //_poolOfItemsParent.GetChild(poolOfItemsMassive[i]).gameObject.SetActive(true);
                    _poolOfItemsParent.GetChild(massive[i]).SetSiblingIndex(i);
                }
                
            }
            
            for (int i = 0; i < childCountPoolSpace; i++)
            {
                Transform child;
                child = _poolSpaceParent.transform.GetChild(i);
                child.SetParent(_poolOfItemsParent.transform);
                i -= 1;
                childCountPoolSpace -= 1;
            }
            
            
            
            
            
            
            
            
            for (int i = 0; i < childCountPoolSpace3; i++)
            {
                Transform child = _poolOfItemsParent.transform.GetChild(_poolOfItemsParent.transform.childCount - i - 1);
                child.SetSiblingIndex(_poolOfItemsParent.transform.childCount - poolSpaceMassive[i]);
            }
            
            

            
            
            
            
            
            childOff.AddListener(() =>
            {
               // print("Hey");
                starsAmount = 0;
                for (int i = 0; i < _poolOfItemsParent.childCount; i++)
                {
                    if (_poolOfItemsParent.transform.GetChild(i).gameObject.activeInHierarchy)
                    {
                        
                        starsAmount += 1;
                    }
                }
                _vector2.x -= 0.3f;
            });




            isChecked = false;
        });
    }


    void Update()
        {
            if (!isChecked)
            {
                /*for (int i = 0; i < _poolOfItemsParent.childCount; i++)
                {
                    if (_poolOfItemsParent.transform.GetChild(i).gameObject.activeInHierarchy)
                    {
                        starsAmount += 1;
                    }
                }*/
                starsAmount = poolOfItemsMassive.Length;
                //print(starsAmount);
                _vector2 = new Vector2(0, 0);
                _vector2.x = -7.5f + (0.3f * starsAmount);
                isChecked = true;
            }
            print(starsAmount);
            _transform.anchorMax = _vector2;
        }

    private void Random()
    {
        Random r = new Random();
        int max = massive.Length;
        massive = new int[max];

        for (int i = 0; i < max; i++)
        {
            bool contains;
            int next;
            do
            {
                next = r.Next(max);
                contains = false;
                for (int index = 0; index < i; index++)
                {
                    int n = massive[index];
                    if (n == next)
                    {
                        contains = true;
                        break;
                    }
                }
            } while (contains);

            massive[i] = next;


        }


    }
    
        private void Random2()
        {
            Random r = new Random();
            int max = poolOfItemsMassive.Length;
            poolOfItemsMassive = new int[max];

            for (int i = 0; i < max; i++)
            {
                bool contains;
                int next;
                do
                {
                    next = r.Next(max);
                    contains = false;
                    for (int index = 0; index < i; index++)
                    {
                        int n = poolOfItemsMassive[index];
                        if (n == next)
                        {
                            contains = true;
                            break;
                        }
                    }
                } while (contains);

                poolOfItemsMassive[i] = next;


            }


        }
        private void Random3()
        {
            Random r = new Random();
            int max = poolSpaceMassive.Length;
            poolSpaceMassive = new int[max];

            for (int i = 0; i < max; i++)
            {
                bool contains;
                int next;
                do
                {
                    next = r.Next(max);
                    contains = false;
                    for (int index = 0; index < i; index++)
                    {
                        int n = poolSpaceMassive[index];
                        if (n == next)
                        {
                            contains = true;
                            break;
                        }
                    }
                } while (contains);

                poolSpaceMassive[i] = next;


            }
        }
    
}
    
    
