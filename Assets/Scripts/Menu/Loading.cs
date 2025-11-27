using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Loading : MonoBehaviour
{
    public static float waitSeconds = 2f;
    private bool isInternetChecked = false;
    private bool isDownloadBundlesCompleted = false;
    private IEnumerator Start()
    {
        FindObjectOfType<CheckConnection>().InternetIsChecked.AddListener(()=>
        {
            Debug.Log("FirstChecked");
            isInternetChecked = true;
        });
        /*FindObjectOfType<LoadingAssets>().LoadingCompleted.AddListener(() =>
        {
            isDownloadBundlesCompleted = true;
            Debug.Log("SecondChecked");
        }); */
        yield return new WaitUntil(() => isInternetChecked);
        //yield return new WaitUntil(() => isDownloadBundlesCompleted);
        

        StartCoroutine(PanelOff());
    }

    private IEnumerator PanelOff()
    {
        yield return new WaitForSeconds(waitSeconds);
        //_cloudsClose.SetActive(true);
        //yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("Menu");
    }
    
}
