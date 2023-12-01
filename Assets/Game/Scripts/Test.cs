
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;
using Image = UnityEngine.UI.Image;

public class Test : MonoBehaviour , IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private Camera mainCamera;
    Vector3 offset;
    void Awake()
    {
        mainCamera = Camera.allCameras[0];
        gameObject.GetComponent<CircleCollider2D>();
        gameObject.GetComponent<Image>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        offset = transform.position - mainCamera.ScreenToWorldPoint(eventData.position);
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector3 newPos = mainCamera.ScreenToWorldPoint(eventData.position);
        transform.position = newPos;
        transform.position = newPos + offset;
    }

    


    public void OnEndDrag(PointerEventData eventData)
    {
    }
}