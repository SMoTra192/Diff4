using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DailyPointDetect : MonoBehaviour, IPointerUpHandler, IPointerDownHandler, IPointerMoveHandler
{
    private Button _button;
    private Vector2 pointPosition;
    public UnityEvent ImageClicked = new();
    [SerializeField] private Camera _camera;
    [SerializeField] private RectTransform _canvas;
    private float _timer = 0f, starttimer;
    private bool isTouched = false;
    private bool isDowned = false;
    private bool isTwoTouched = false;

    private void Awake()
    {
        starttimer = _timer;
        _button = GetComponent<Button>();

    }

    public Vector2 PointPosition()
    {
        return pointPosition;
    }

    public void OnMouseDown()
    {
        //print(isDowned);
        //isDowned = true;
        // print(isDowned);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        bool isFinished;
        isFinished = FindObjectOfType<DailyEntryPoint>().IsFin();
        if (!isTouched && Input.touchCount != 2 && !isTwoTouched && !isFinished)
        {
            FindObjectOfType<TakeTime>().timeDown.Invoke();
            RectTransformUtility.ScreenPointToLocalPointInRectangle(_canvas, Input.mousePosition, _camera,
                out pointPosition
            );
            ImageClicked.Invoke();

            
           
        }

        if (Input.touchCount != 2)
        {
            if (isDowned) isDowned = false;
            if (isTouched)
            {
                isTouched = false;
            }

            isTwoTouched = false;
        }
        
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        isDowned = true;
        if (Input.touchCount == 2)
        {
            isTwoTouched = true;
           // print("Downed");
            isTouched = true;
        }
        
    }

    public void OnPointerMove(PointerEventData eventData)
    {
        if (Input.touchCount == 2)
        {
            isTwoTouched = true;
            //print("moved");
        }
        if (isDowned)
        {
            
           // print("moved2");
            //FindObjectOfType<ZoomPicture>().Zoom();
            isTouched = true;
        }


    }


}