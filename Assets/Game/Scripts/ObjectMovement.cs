using System;
using Coffee.UIEffects;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.UIElements;

[RequireComponent(typeof(Rigidbody2D))] 
[RequireComponent(typeof(BoxCollider2D))]

public class ObjectMovement : MonoBehaviour , IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [SerializeField] private ScrollRect _rect;
    private UIShiny _shiny;
    private Camera mainCamera;
    Vector3 offset;
    [SerializeField] private GameObject positionToPoint;
    private GameObject PoolOfItemsParent,PoolSpaceParent;
    [SerializeField] private float multiplicatorSize = 4;
    private Vector3 position;
    private int index;
    private bool isDragged = false , isStartDrag = false , isOnDrag = false;
    private Vector2 startPos, dragPos;
    private Vector2 firstPos,SecondPos;
    int stats;
    private bool objMoved = false;
    private string objIndexName;
    void Awake()
    {
        PoolOfItemsParent = GameObject.Find("PoolOfItems");
        PoolSpaceParent = GameObject.Find("PoolSpace");
        //_shiny = transform.GetChild(0).GetComponent<UIShiny>();
        gameObject.transform.position = positionToPoint.transform.position;
        mainCamera = Camera.allCameras[0];
        gameObject.GetComponent<BoxCollider2D>().isTrigger = true;
        gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        firstPos = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        SecondPos = firstPos;
        gameObject.transform.localScale *= multiplicatorSize;
        
        //_shiny.Play();
        offset = transform.position - mainCamera.ScreenToWorldPoint(eventData.position);
        startPos = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        {
            
        }
        
    }

    public void OnDrag(PointerEventData eventData)
    {
        firstPos = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        stats = 0;
        for (int i = 0; i < PoolOfItemsParent.transform.childCount; i++)
        {
            if (PoolOfItemsParent.transform.GetChild(i).gameObject.activeInHierarchy)
            {
                stats += 1;
            }
        }
        if (gameObject.transform.IsChildOf(PoolOfItemsParent.transform))
            _rect.horizontalNormalizedPosition -= (firstPos.x - SecondPos.x) * (0.05f * (25/stats));
        dragPos = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        //print(startPos.y);
        //print(dragPos.y);
        //print(dragPos.y + startPos.y);
        if (dragPos.y + startPos.y > startPos.y * 1.9f && isDragged == false)
        {
            
            isStartDrag = true;
            isDragged = true;
            isOnDrag = true;
        }
        
        
        
       
            
        
        
        
        
        
        if (isStartDrag)
        {
            
            objIndexName = $"Level_{PlayerPrefs.GetInt("PuzzleLevelLoad")}_Name_{ObjIndex()}";
            string prefName = PlayerPrefs.GetString(objIndexName);
            if (!prefName.Contains(gameObject.name))
            {
                //print("HEAY");
                PlayerPrefs.SetInt("Childs",PlayerPrefs.GetInt("Childs") + 1);
                
            }
            
            
            //PlayerPrefs.GetString(objIndexName);
            PlayerPrefs.SetString(objIndexName,gameObject.name);
            
            //print(prefName);
            print(PlayerPrefs.GetInt("Childs"));
            if (transform.IsChildOf(PoolOfItemsParent.transform))
            {
                transform.SetParent(PoolSpaceParent.transform);
                FindObjectOfType<RectTransformLeft>().childOff.Invoke();
            }
            
            
            
            
              //tempObject.transform.position = gameObject.transform.position;
            position = gameObject.transform.position;
            //GetComponent<CanvasGroup>().blocksRaycasts = false;//
            index = transform.GetSiblingIndex();
            //tempObject.transform.SetParent(PoolOfItemsParent);
              //tempObject.transform.SetSiblingIndex(index);
            
            
            //tempObject.transform.SetSiblingIndex(transform.GetSiblingIndex());//
            
            isStartDrag = false;
            
        }
        if (!transform.IsChildOf(PoolOfItemsParent.transform))gameObject.transform.SetAsLastSibling();
        
        
        if(isOnDrag)
        {
            Vector3 newPos = mainCamera.ScreenToWorldPoint(eventData.position);
            
            Vector3 upp = new Vector3(0, 0.3f);
            transform.position = newPos;
            transform.position = newPos + offset + upp;
        }

        SecondPos = firstPos;
    }




    public void OnEndDrag(PointerEventData eventData)
    {
        
            gameObject.transform.localScale /= multiplicatorSize;
    }

    int ObjIndex()
    {
        string ObjName = gameObject.name;
        string Level;
        int index;
        if (ObjName.Length >= 13) Level = ObjName.Substring(ObjName.Length - 2);
        else
        {
            Level = ObjName.Substring(ObjName.Length - 1);
        }

      
        index = int.Parse(Level);
        return index;
    }
    
}