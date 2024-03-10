using System;
using Unity.Services.Core;
using Unity.Services.Core.Environments;
using UnityEngine;
 
public class InitUnity : MonoBehaviour {
    
    public string environment = "findit.NixPix";
 
    async void Start() {
        try {
            var options = new InitializationOptions()
                .SetEnvironmentName(environment);
 
            await UnityServices.InitializeAsync(options);
        }
        catch (Exception exception) {
            // An error occurred during initialization.
        }
    }
}