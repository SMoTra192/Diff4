using System.Collections;
using UnityEngine;

public class PrintKeyScript : MonoBehaviour
{
    [SerializeField] private Camera _screenShotCamera;
    private string nowDate;

    private void Awake()
    {
        _screenShotCamera.GetComponent<Camera>();
    }

    public void ScreenShot()
    {
        _screenShotCamera.depth = 0;
        nowDate = System.DateTime.Now.ToString("MM-dd-yy(HH-mm-ss)");
        print(nowDate);
        ScreenCapture.CaptureScreenshot($"{nowDate}.png");
        StartCoroutine(wait());
    }

    private IEnumerator wait()
    {
        yield return new WaitForSeconds(0.01f);
        _screenShotCamera.depth = -10;
    }
}
