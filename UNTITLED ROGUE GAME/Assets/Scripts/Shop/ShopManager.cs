using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour
{
    public int coins = 1000;
    public Text coinsUI;

    public ItemSO[] shopItemsSO;
    public Button[] purchaseButtons;
    public ShopTemplate[] shopPanels;

    public InventarySO inventoryData;

    // Start is called before the first frame update
    void Start()
    {
        coinsUI.text = coins.ToString();
        LoadPanels();
        CheckPurchaseable();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddCoins()
    {
        coins++;
        coinsUI.text = "Coins: " + coins.ToString();
        CheckPurchaseable();
    }

    public void LoadPanels()
    {
        for (int i = 0; i < shopItemsSO.Length; i++)
        {
            shopPanels[i].itemName.text = shopItemsSO[i].itemName;
            shopPanels[i].itemDescription.text = shopItemsSO[i].description;
            shopPanels[i].itemCost.text = shopItemsSO[i].cost.ToString();
            shopPanels[i].itemSprite.sprite = shopItemsSO[i].itemImage;
        }
    }

    public void CheckPurchaseable()
    {
        for(int i = 0;i < shopItemsSO.Length;i++)
        {
            if(coins >= shopItemsSO[i].cost)
            {
                purchaseButtons[i].interactable = true;
            }

            else
            {
                purchaseButtons[i].interactable = false;
            }
        }
    }

    public void PurchaseItem(int btnNumber)
    {
        if(coins >= shopItemsSO[btnNumber].cost)
        {
            coins = coins - shopItemsSO[btnNumber].cost;
            coinsUI.text = coins.ToString();
            inventoryData.AddItem(shopItemsSO[btnNumber], 1);
            CheckPurchaseable();
        }
    }

}
