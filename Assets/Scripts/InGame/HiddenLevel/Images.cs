using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.UI;

public class Images : MonoBehaviour
{
    [SerializeField] private Image image1, image2, image3;
    private Sprite _sprite;

    private void Start()
    {
        AsyncOperationHandle<Sprite> sprite = Addressables.LoadAssetAsync<Sprite>($"Assets/GameImages/HIdden/{PlayerPrefs.GetInt("PuzzleLevelLoad")}/Image1.png");
        sprite.Completed += Sprite_Completed;
        
        AsyncOperationHandle<Sprite> sprite2 = Addressables.LoadAssetAsync<Sprite>($"Assets/GameImages/HIdden/{PlayerPrefs.GetInt("PuzzleLevelLoad")}/Image2.png");
        sprite2.Completed += Sprite_Completed2;
        
        AsyncOperationHandle<Sprite> sprite3 = Addressables.LoadAssetAsync<Sprite>($"Assets/GameImages/HIdden/{PlayerPrefs.GetInt("PuzzleLevelLoad")}/Image3.png");
        sprite3.Completed += Sprite_Completed3;
        
    }
    
    private void Sprite_Completed(AsyncOperationHandle<Sprite> handle)
{
    if (handle.Status == AsyncOperationStatus.Succeeded)
    {
        _sprite = handle.Result;
        image1.sprite = _sprite;
        // Sprite ready for use
    }
}
private void Sprite_Completed2(AsyncOperationHandle<Sprite> handle)
{
    if (handle.Status == AsyncOperationStatus.Succeeded)
    {
        _sprite = handle.Result;
        image2.sprite = _sprite;
        // Sprite ready for use
    }
}
private void Sprite_Completed3(AsyncOperationHandle<Sprite> handle)
{
    if (handle.Status == AsyncOperationStatus.Succeeded)
    {
        _sprite = handle.Result;
        image3.sprite = _sprite;
        // Sprite ready for use
    }
}
}
