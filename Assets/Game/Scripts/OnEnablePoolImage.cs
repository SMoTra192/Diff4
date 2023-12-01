using System.Collections;
using UnityEngine;

public class OnEnablePoolImage : MonoBehaviour
{
    
    [SerializeField] private Vector3 Scale = new Vector3(1.5f,1.5f,1f);
    [SerializeField] private GameObject image;
    
    private void Awake()
    {
        image.transform.localScale = Scale;
    }
    
    private void OnEnable()
    {
        StartCoroutine(Scaling());
    }

    IEnumerator Scaling()
    {
        for (float x = 0.05f; x <= Scale.x; x += 0.05f)
        {
            Vector3 scale = new Vector3(x, x, 1);
            image.transform.localScale = scale;
            yield return new WaitForSeconds(0.01f);
        }

        
    }
}


