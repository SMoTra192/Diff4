using TMPro;
using UnityEngine;
public class TotalLevels : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private Transform contentParent;
    private int index;
    private void Awake()
    {
        
    }

    private void Update()
    {
        _text.text = $"{PlayerPrefs.GetInt("CompletedLevels")}/{contentParent.childCount}";
        index = contentParent.childCount;
        PlayerPrefs.SetInt("Index",index);
    }
}
