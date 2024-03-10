using Firebase.Analytics;
using UnityEngine;

public class FirebaseStartLevel : MonoBehaviour
{
    private string start_level;
    void Start()
    {
        FirebaseAnalytics.LogEvent("start_level","level","level index");
        
    }

    
}
