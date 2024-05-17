using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryController: MonoBehaviour
{
    [SerializeField]
    private UIInventoryPage inventoryUI;

    [SerializeField]
    private InventarySO inventarySO;

    public int invCharSize;

    public int invBagSize;

    public int invBaseSize;

    private void Start()
    {
        PrepareUI();
        PrepareInventoryData();
        foreach (var item in inventarySO.GetCurrentInventoryState())
        {
            inventoryUI.UpdateData(item.Key, item.Value.item.itemImage);
        }
    }

    private void PrepareInventoryData()
    {
        //inventarySO.Initialize();
        inventarySO.OnInventoryUpdated += UpdateInventoryUI;
        foreach (var item in inventarySO.GetCurrentInventoryState())
        {
            inventoryUI.UpdateData(item.Key, item.Value.item.itemImage);
        }
    }

    private void UpdateInventoryUI(Dictionary<int, InventoryItem> inventoryState)
    {
        inventoryUI.ResetAllItems();
        foreach (var item in inventarySO.GetCurrentInventoryState())
        {
            inventoryUI.UpdateData(item.Key, item.Value.item.itemImage);
        }
    }

    private void PrepareUI()
    {
        inventoryUI.InitializeInvUI(invCharSize, invBagSize, invBaseSize);
        this.inventoryUI.OnSwapItems += HandleSwapItems;
        this.inventoryUI.OnStartDragging += HandleDragging;
        this.inventoryUI.OnItemActionRequested += HandleItemActionRequest;
    }

    private void HandleSwapItems(int itemIndex1, int itemIndex2)
    {
        inventarySO.SwapItems(itemIndex1, itemIndex2);
        
    }

    private void HandleDragging(int itemIndex)
    {
        InventoryItem inventoryItem = inventarySO.GetItemAt(itemIndex);
        if (inventoryItem.IsEmpty) return;
        inventoryUI.CreateDraggedItem(inventoryItem.item.itemImage);
    }

    private void HandleItemActionRequest(int itemIndex)
    {
        throw new NotImplementedException();
    }
    /*
private void Update()
{
if(inventoryUI.isActiveAndEnabled == false)
{
  inventoryUI.Show();

}
else
{
  inventoryUI.Hide();
}
}*/
}
