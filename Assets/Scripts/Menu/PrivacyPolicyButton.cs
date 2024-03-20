using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PrivacyPolicyButton : MonoBehaviour
{
    // Start is called before the first frame update
    private Button _button;
    [SerializeField] private string _urlPrivacyPolicy;

    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    void Start()
    {
        _button = GetComponent<Button>();
        _button.onClick.AddListener(()=>
        {
            Application.OpenURL(_urlPrivacyPolicy);
        });
    }
}
