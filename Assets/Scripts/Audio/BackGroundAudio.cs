using UnityEngine;
using UnityEngine.SceneManagement;

public class BackGroundAudio : MonoBehaviour
{
    public string tag;

    private void Awake()
    {
         
    
            GameObject obj = GameObject.FindWithTag(tag);
            
            if(obj != null) Destroy(gameObject);
            else
            {
                gameObject.tag = tag;
                DontDestroyOnLoad(gameObject);      
            }
        


    } 
}

    

