using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonGoHome : MonoBehaviour
{
    [SerializeField] private string MenuName;

    private Button _button;

    private void Awake()
    {
        _button = gameObject.GetComponent<Button>();
        _button.onClick.AddListener(GoHomeButton);
    }

    public void GoHomeButton()
    {
        SceneManager.LoadScene(MenuName);
    }
}
