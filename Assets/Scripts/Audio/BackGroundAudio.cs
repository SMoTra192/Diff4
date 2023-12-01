using UnityEngine;
using UnityEngine.SceneManagement;

public class BackGroundAudio : MonoBehaviour
{
    private string[] tag;

    private void Awake()
    {
        tag = new string[2];
        tag[0] = "InGame";
        tag[1] = "InPuzzleGame";
        foreach (var tag in tag)
        {
            GameObject obj = GameObject.FindWithTag(tag);
            Destroy(obj);
        }


        string[] newTags;
        newTags = new string[2];
        newTags[0] = "Menu";
        newTags[1] = "Puzzle_Menu";


        GameObject obj2 = GameObject.FindWithTag(newTags[0]);
        if (obj2 == null) obj2 = GameObject.FindWithTag(newTags[1]);

        if (obj2 != null) Destroy(gameObject);
        else
        {
            gameObject.tag = newTags[0];
            DontDestroyOnLoad(gameObject);


        }
    }
}

    

