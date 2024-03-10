
using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class ObjectCompare : MonoBehaviour
{
    //[SerializeField] private GameObject tempObject;
    private GameObject inGameSceneObject;
    //[SerializeField] private Transform tempfolder;
    
    private GameObject _poolObject;
    private AudioSource _audioSource;
    //[SerializeField] private ParticleSystem particle;
    private string _name;
    private string _tagName;
    private int _inScenePrefabIndex;
    public UnityEvent isCompared = new();

    private void Awake()
    {
        Vibration.Init();
        inGameSceneObject = GameObject.Find($"inScenePrefab_{gameObject.transform.GetSiblingIndex() + 1}");
        _audioSource = transform.GetComponentInParent<AudioSource>();
       // _audioSource.GetComponent<AudioSource>();
        //_objectFolder = GameObject.FindGameObjectWithTag("TheGameScene");
        //Transform tempObject = tempfolder.GetChild(0);
        _tagName = gameObject.tag;
    }

    
    

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.CompareTag(_tagName))
        
        {
           //print("YES");
            int starsAmount = PlayerPrefs.GetInt("StarsAmount");
            PlayerPrefs.SetInt("StarsAmount", starsAmount - 1);
            FindObjectOfType<TheGameEnd>()._event.Invoke();
            Transform Image = col.transform.GetChild(0);
            var InGameSceneValue = $"PuzzleLevel_{PlayerPrefs.GetInt("PuzzleLevelLoad")}_{col.name}";
            //print(col.name);
            PlayerPrefs.SetString(InGameSceneValue,col.name);
            var childName = PlayerPrefs.GetString($"Level_{PlayerPrefs.GetInt("PuzzleLevelLoad")}_Name_{ObjIndex()}");
            if (childName.Contains($"PoolPrefab_{ObjIndex()}"))
            {
                PlayerPrefs.SetInt("Childs", PlayerPrefs.GetInt("Childs") - 1);
            }
            Destroy(gameObject);
            //tempObject.transform.SetParent(tempfolder);
            //tempObject.transform.position = tempfolder.transform.position;
            Image.gameObject.SetActive(true);
                //particle.transform.position = inGameSceneObject.transform.position;
            Vibration.VibrateAndroid(35);
            //particle.Play();
            //_audioSource.PlayOneShot(_audioSource.clip);
            RandomEnableImages.isImageSet = true;
        }
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
