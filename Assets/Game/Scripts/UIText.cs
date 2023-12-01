using TMPro;
using UnityEngine;

public class UIText : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI hintText;
    private int hintsCount;
    

    private void Awake()
    {
        UI.hint = "HintPref";
            hintText.GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
        hintsCount = PlayerPrefs.GetInt(UI.hint);
        if (hintsCount > 0)
            hintText.text = $"{hintsCount}";
        else
        {
            hintText.text = "AD";
        }

    }
}
