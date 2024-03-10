
using UnityEngine;
using UnityEngine.SceneManagement;

public class PuzzleMenuPicture : MonoBehaviour
{
    [SerializeField] private GameObject completedImage, unCompletedImage, closedImage;
    
    private void Update()
    {
        
        int buttonIndex = gameObject.transform.GetSiblingIndex()+1;
        int puzzleLevelIndex = PlayerPrefs.GetInt("CompletedPuzzleLevels");
        if (puzzleLevelIndex > buttonIndex)
        {
            unCompletedImage.SetActive(false);
            completedImage.SetActive(true);
            closedImage.SetActive(false);
        }
        if (puzzleLevelIndex == buttonIndex)
        {
            unCompletedImage.SetActive(true);
            closedImage.SetActive(false);
        }

        if (puzzleLevelIndex < buttonIndex)
        {
            
            unCompletedImage.SetActive(false);
            closedImage.SetActive(true);
        }
    }
}
