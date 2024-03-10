using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MAXDegugger : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        MaxSdkCallbacks.OnSdkInitializedEvent += (MaxSdkBase.SdkConfiguration sdkConfiguration) => {
            // Show Mediation Debugger
            MaxSdk.ShowMediationDebugger();
        }; 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
