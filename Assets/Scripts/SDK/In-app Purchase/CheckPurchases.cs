using System.Collections;
using System.Collections.Generic;
using Facebook.Unity;
using UnityEngine;
using UnityEngine.Purchasing;
using UnityEngine.Purchasing.Extension;
using Product = UnityEngine.Purchasing.Product;

public class CheckPurchases : MonoBehaviour
{
    [SerializeField] private string RemoveAds_ID;
    [SerializeField] private GameObject _adsRemoveObject;
int boolValue;

private void Start()   
    {   
        boolValue = PlayerPrefs.GetInt("ADSDisable");
        CheckAdsPurchase();
    }
    public void onPurchaseCompleted(Product product)
    {
            if(product.definition.id == RemoveAds_ID)
            {
                Debug.Log("removeAds Purchased");
                boolValue = 1;
                PlayerPrefs.SetInt("ADSDisable",boolValue);
                PlayerPrefs.SetInt("ADSPurchased",1);
                MaxSdk.HideBanner("f6924db41060fb9d");
            }
            
            CheckAdsPurchase();
    }
    public void OnPurchaseFailed(Product product,PurchaseFailureDescription description)
    {
        Debug.Log($"{product.definition.id} failed as a result of {description.message}");
    }

    private void CheckAdsPurchase()
    {
        if(PlayerPrefs.GetInt("ADSPurchased") == 1) _adsRemoveObject.SetActive(false);
    }   
}
