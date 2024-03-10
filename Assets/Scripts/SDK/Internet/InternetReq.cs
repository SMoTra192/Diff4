using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Networking;
using UnityEngine.Networking;

public class InternetReq : MonoBehaviour
{
    [SerializeField] private string[] uris;

    private void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    public IEnumerator TestConnection(Action<bool> Callback)
    {
        foreach (var uri in uris)
        {
            UnityWebRequest request = UnityWebRequest.Get(uri);

            yield return request.SendWebRequest();
            Debug.Log( $"(Gamelog) >>> [InternetReq] >>> (TestConnection) >>> {uri} >>> CheckRequest is {!request.isNetworkError}");
            if (request.isNetworkError == false)
            {
                Callback(true);
                yield break;
            }
            
        }

        Callback(false);
    }
}
