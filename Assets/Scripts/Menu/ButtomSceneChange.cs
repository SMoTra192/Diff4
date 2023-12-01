using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtomSceneChange : MonoBehaviour
{
    [SerializeField] private string _SceneName;

    public void ButtonClick()
    {
        SceneManager.LoadScene(_SceneName);
    }
}
