using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;
using TMPro;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.Events;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.SceneManagement;
using UnityEngine.UI;



public class LoadingAssets : MonoBehaviour
{

    //public bool ClearCache;
    private bool isCompletedDownload = false;
    private bool isDownloading = true;
    public UnityEvent LoadingCompleted = new();
    
    [SerializeField] private Slider _loadingBar;
    [SerializeField] private TextMeshProUGUI _textPercentage;

    
    async void Awake()
    {
        Debug.Log(Addressables.RuntimePath);
        var resourceLocator = await Addressables.InitializeAsync().Task;
        var allKeys = resourceLocator.Keys.ToList();
        
        var totalDownloadSizeKb = BToKb(await Addressables.GetDownloadSizeAsync(allKeys).Task);
        
        Debug.Log("Download kbs required: " + totalDownloadSizeKb);
        var downloadedKb = 0f;
        foreach (var key in allKeys)
        {
            var keyDownloadSizeKb = BToKb(await Addressables.GetDownloadSizeAsync(key).Task);
            if (keyDownloadSizeKb <= 0)
            {
                continue;
            }
            
           
            var keyDownloadOperation = Addressables.DownloadDependenciesAsync(key);
            
            while (!keyDownloadOperation.IsDone)
            {
                await Task.Yield();
                var acquiredKb = downloadedKb + (keyDownloadOperation.PercentComplete * keyDownloadSizeKb);
                var totalProgressPercentage = (acquiredKb / totalDownloadSizeKb);
                //_loadingBar.value = totalProgressPercentage;
                _textPercentage.text = $"Loading Assets {Math.Round(totalProgressPercentage * 100)}%";
                Debug.Log("Download progress: " + (totalProgressPercentage * 100).ToString("0.00") + "% - "  + acquiredKb + "kb /" + totalDownloadSizeKb + "kb");    
            }
            
            new WaitUntil(() => keyDownloadOperation.IsDone);
            StartCoroutine(iwait());
            //downloadedKb += keyDownloadSizeKb;

        }
        

        if (totalDownloadSizeKb <= 0)
        {
            //_loadingBar.gameObject.SetActive(false);
            _textPercentage.text = $" ";
            StartCoroutine(iwait());
        }
    }

    private void Update()
    {
        
        if ( !isDownloading && !isCompletedDownload)
        {
            isCompletedDownload = true;
           
        }
        
    }

    static float BToKb(long bytes)
    {
        return bytes / 1000f;
    }
    
   

private IEnumerator iwait()
{
    yield return null;
    
    LoadingCompleted.Invoke();
}

    }
    