using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Loading : MonoBehaviour
{
    public static float waitSeconds = 2f;
    //[SerializeField] private GameObject _cloudsClose;
    private void Awake()
    {
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
