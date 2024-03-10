using System.Collections;
using System.Collections;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.Purchasing;
using System.Collections.Generic;

[Serializable]
public class ConsumableItem {
    public string Name;
    public string Id;
    public string desc;
    public float price;
}
[Serializable]
public class NonConsumableItem
{
    public string Name;
    public string Id;
    public string desc;
    public float price;
}
[Serializable]
public class SubscriptionItem
{
    public string Name;
    public string Id;
    public string desc;
    public float price;
    public int timeDuration;// in Days
}

public class Intialize : MonoBehaviour, IStoreListener
{
    IStoreController m_StoreContoller;

    //public ConsumableItem cItem;
    public NonConsumableItem ncItem;
    //public SubscriptionItem sItem;

    //public TMP_InputField inp;


   // public Data data;
    //public Payload payload;
   // public PayloadData payloadData;
    private void Start()
    {
        SetupBuilder();
        
    }

    #region setup and initialize
    void SetupBuilder()
    {

        var builder = ConfigurationBuilder.Instance(StandardPurchasingModule.Instance());

        //builder.AddProduct(cItem.Id, ProductType.Consumable);
        builder.AddProduct(ncItem.Id, ProductType.NonConsumable);
        //builder.AddProduct(sItem.Id, ProductType.Subscription);

        UnityPurchasing.Initialize(this, builder);
    }
    public void OnInitialized(IStoreController controller, IExtensionProvider extensions)
    {
        print("Success");
        m_StoreContoller = controller;
        CheckNonConsumable(ncItem.Id);
       // CheckSubscription(sItem.Id);
    }
    #endregion


    #region button clicks 
    public void Consumable_Btn_Pressed()
    {
        //AddCoins(50);
       // m_StoreContoller.InitiatePurchase(cItem.Id);
    }

    public void NonConsumable_Btn_Pressed()
    {
        //RemoveAds();
        m_StoreContoller.InitiatePurchase(ncItem.Id);

    }

    public void Subscription_Btn_Pressed()
    {
        //ActivateElitePass();
      //  m_StoreContoller.InitiatePurchase(sItem.Id);
    }
    #endregion


    #region main
    //processing purchase
    public PurchaseProcessingResult ProcessPurchase(PurchaseEventArgs purchaseEvent)
    {
        //Retrive the purchased product
        var product = purchaseEvent.purchasedProduct;

        print("Purchase Complete" + product.definition.id);

        /*if (product.definition.id == cItem.Id)//consumable item is pressed
        {
            string receipt = product.receipt;
            data = JsonUtility.FromJson<Data>(receipt);
            payload = JsonUtility.FromJson<Payload>(data.Payload);
            payloadData = JsonUtility.FromJson<PayloadData>(payload.json);

            int quantity = payloadData.quantity;

            for (int i = 0; i < quantity; i++)
            {
                AddCoins(50);
            }
            
        }
        else 
        else if (product.definition.id == sItem.Id)//subscribed
        {
            ActivateElitePass();
        }
*/
        if (product.definition.id == ncItem.Id)//non consumable
        {
            print("Purchased");
            PlayerPrefs.SetInt("ADSDisable",1);
            MaxSdk.HideBanner("f6924db41060fb9d");
        }
        return PurchaseProcessingResult.Complete;
    }
    #endregion




    void CheckNonConsumable(string id) {
        if (m_StoreContoller!=null)
        {
            var product = m_StoreContoller.products.WithID(id);
            if (product!=null)
            {
                if (product.hasReceipt)//purchased
                {
                    print("Purchased");
                    PlayerPrefs.SetInt("ADSDisable",1);
                    MaxSdk.HideBanner("f6924db41060fb9d");
                    
                }
                else {
                    print("notPurchased");
                    PlayerPrefs.SetInt("ADSDisable",0);
                    
                }
            }
        }
    }

   

    
    public void OnInitializeFailed(InitializationFailureReason error)
    {
        print("failed" + error);
    }

    public void OnInitializeFailed(InitializationFailureReason error, string message)
    {
        print("initialize failed" + error + message);
    }



    public void OnPurchaseFailed(Product product, PurchaseFailureReason failureReason)
    {
        print("purchase failed" + failureReason);
    }
    

}
