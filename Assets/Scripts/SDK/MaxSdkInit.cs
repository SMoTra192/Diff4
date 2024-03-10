using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaxSdkInit : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        MaxSdkCallbacks.OnSdkInitializedEvent += (MaxSdkBase.SdkConfiguration sdkConfiguration) => {
            // AppLovin SDK is initialized, start loading ads
        };
        MaxSdk.SetSdkKey("zq2X1FfdfeIMOsmepidyMNbeqvHKzJyNwy6EI2lT_14Ns_yAy-XVUTSsThDAZ5-AqDJ2OU0CLSeP7euEiV4wor");
        MaxSdk.SetUserId("com.findit.difference.puzzle");
        MaxSdk.InitializeSdk();
 
    }

    
}
