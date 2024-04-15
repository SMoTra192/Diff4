using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DailyZoom : MonoBehaviour 
{
    Vector3 touchStart;
    private float zoomOutMin = 1;
    private float zoomOutMax = 3.3f;

    [SerializeField] private Image _firstImage, _secondImage;

    private float _currentValue, _value;
    private Vector3 _scale;
    private float xPos, yPos, xPos2, yPos2;

    private Vector3 startPosPic1, startPosPic2;

    [SerializeField] private RectTransform _parent1, _parent2;


    private float minX, maxX, minY, maxY;
    private float minX2, maxX2, minY2, maxY2;

    private bool isHintPressed = false;
    private int firstId;
    
    
    private bool inFound = false;
    private DailyLevelImagesInstance _spot;
    private void Awake()
    {
        
            _spot = GameObject.Find("Canvas").GetComponent<DailyLevelImagesInstance>();
            _spot.onSpot.AddListener(() =>
            {
                _firstImage = FindObjectOfType<FirstPicture>().GetComponent<Image>();
                _secondImage = FindObjectOfType<SecondPicture>().GetComponent<Image>();
                _value = zoomOutMax;
        
                minX = _firstImage.transform.position.x - _firstImage.sprite.bounds.size.x/2;
                maxX = _firstImage.transform.position.x + _firstImage.sprite.bounds.size.x/2;
                minY = _firstImage.transform.position.y - _firstImage.sprite.bounds.size.y/2;
                maxY = _firstImage.transform.position.y + _firstImage.sprite.bounds.size.y/2;
        
        
        
        
                minX2 = _parent2.transform.position.x - _secondImage.sprite.bounds.size.x/2;
                maxX2 = _parent2.transform.position.x + _secondImage.sprite.bounds.size.x/2;
                minY2 = _parent2.transform.position.y - _secondImage.sprite.bounds.size.y/2;
                maxY2 = _parent2.transform.position.y + _secondImage.sprite.bounds.size.y/2;

_spot.onSpotNext.Invoke();
            });
            
            
        
        
        FindObjectOfType<HintMech>().hintPressed.AddListener(() =>
        {
            isHintPressed = true;
            //_firstImage.transform.position = FindObjectOfType<ReferenceRightIcons>().HintTransform();
            //_secondImage.transform.position = FindObjectOfType<ReferenceRightIcons>().HintTransform2();
            zoom(-10f);
            isHintPressed = false;
        });
    }

    void Update()
    {
        
        
        _firstImage.transform.localScale = new Vector3(2, 2, 2);
        if(Input.touchCount == 1)
        {
            var touch = Input.GetTouch(0);
            if(touch.phase == TouchPhase.Began)
            {
                firstId = touch.fingerId;
            }
        }

        // Later rather use this to iterate the touches
        var touches = Input.touches;

        for(var i = 0; i < touches.Length; i++)
        {
            var currentTouch = touches[i];

            // Now from here you can always check the 
            if(currentTouch.fingerId == firstId)
            {
                PanPicture();
            }
            else
            {
                // ...
            }
        }
        
        
       if (Input.touchCount == 2)
       {
           
            Touch touchZero = Input.GetTouch(0);
            Touch touchOne = Input.GetTouch(1);

            Vector2 touchZeroPrevPos = touchZero.position - touchZero.deltaPosition;
            Vector2 touchOnePrevPos = touchOne.position - touchOne.deltaPosition;

            float prevMagnitude = (touchZeroPrevPos - touchOnePrevPos).magnitude;
            float currentMagnitude = (touchZero.position - touchOne.position).magnitude;

            float difference = currentMagnitude - prevMagnitude;

            zoom(difference * 0.003f);
        }

       
        
        zoom(Input.GetAxis("Mouse ScrollWheel"));

    }

    private void PanPicture()
    {
        
        if (Input.GetMouseButtonDown(0))
        {
            touchStart = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
            startPosPic1 = _firstImage.transform.position;
            startPosPic2 = _secondImage.transform.position;
            
        }

        if (Input.GetMouseButton(0))
        {
            Vector3 direction;
            direction = touchStart - Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
                
            Vector3 picture1Pos = startPosPic1 - direction;
            Vector3 picture2Pos = startPosPic2 - direction;
            
            _firstImage.transform.position = ClampImage(picture1Pos);
            _secondImage.transform.position = ClampImage2(picture2Pos);
            
            
            
            
        
        }
        
    }
        void zoom(float increment)
        {
            _currentValue = Mathf.Clamp(_currentValue + increment, zoomOutMin, zoomOutMax);
            _value = Mathf.Clamp(_value - increment, zoomOutMin, zoomOutMax);

            if (!isHintPressed)
            {
                _firstImage.transform.localScale = new Vector3(_currentValue, _currentValue, _currentValue);
                _firstImage.transform.position = ClampImage(_firstImage.transform.position);
                _secondImage.transform.localScale = new Vector3(_currentValue, _currentValue, _currentValue);
                _secondImage.transform.position = ClampImage2(_secondImage.transform.position);
            }
            else
            {
                _firstImage.transform.localScale = new Vector3(1, 1, 1);
                _secondImage.transform.localScale = new Vector3(1, 1, 1);
            }
            
           
        }

        private Vector3 ClampImage(Vector3 targetPos)
        {
            float ImageHeight = _value *1.477f;
            float ImageWidth = _value *1.477f * (_firstImage.sprite.bounds.size.x/_firstImage.sprite.bounds.size.y); ///////1.477
            
            
            float minX = (this.minX + ImageWidth);
            float maxX = (this.maxX - ImageWidth);
            float minY = (this.minY + ImageHeight); 
            //print(minY);
            float maxY = (this.maxY - ImageHeight);

            float newX = Mathf.Clamp(targetPos.x, minX, maxX);
            float newY = Mathf.Clamp(targetPos.y, minY, maxY);

            return new Vector3(newX, newY, targetPos.z);
            
            
        }
        private Vector3 ClampImage2(Vector3 targetPos)
        {
            float ImageHeight = _value*1.477f;
            float ImageWidth = _value *1.477f * (_secondImage.sprite.bounds.size.x/_secondImage.sprite.bounds.size.y);
            
            
            float minX = (this.minX2 + ImageWidth);
            float maxX = (this.maxX2 - ImageWidth);
            float minY = (this.minY2 + ImageHeight); 
            float maxY = (this.maxY2- ImageHeight);

            float newX = Mathf.Clamp(targetPos.x, minX, maxX);
            float newY = Mathf.Clamp(targetPos.y, minY, maxY);

            return new Vector3(newX, newY, targetPos.z);
            
            
        }

    
        
}

