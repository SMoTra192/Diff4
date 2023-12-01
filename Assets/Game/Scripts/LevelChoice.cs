using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class LevelChoice : MonoBehaviour
{
    [SerializeField] private Transform parent;
    [SerializeField] private Button[] child;

    private void Awake()
    {
        child = parent.GetComponentsInChildren<Button>();
    }
    
}

