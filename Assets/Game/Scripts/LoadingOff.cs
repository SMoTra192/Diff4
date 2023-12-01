using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingOff : MonoBehaviour
{
    
    public static float waitSeconds = 3f;

    private void Awake()
    {
        StartCoroutine(PanelOff());
    }

    private IEnumerator PanelOff()
    {
        yield return new WaitForSeconds(waitSeconds);
        SceneManager.LoadScene("Menu");
    }
    
}
