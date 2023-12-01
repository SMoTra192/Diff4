
using UnityEngine;
using UnityEngine.SceneManagement;

public class PuzzleMenuPicture : MonoBehaviour
{
    [SerializeField] private GameObject completedImage, unCompletedImage, closedImage;
    
    private void Update()
    {
        
        int buttonIndex = gameObject.transform.GetSiblingIndex()+1;
        int puzzleLevelIndex = PlayerPrefs.GetInt("CompletedPuzzleLevels");
        int PuzzleLevelValue = PlayerPrefs.GetInt($"{SceneUtility.GetBuildIndexByScenePath($"Assets/Scenes/PuzzleLevel_{buttonIndex}.unity")}");
        if (PuzzleLevelValue == 1)
        {
            unCompletedImage.SetActive(false);
            completedImage.SetActive(true);
            closedImage.SetActive(false);
        }
        if (PuzzleLevelValue != 1 && puzzleLevelIndex == buttonIndex)
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
