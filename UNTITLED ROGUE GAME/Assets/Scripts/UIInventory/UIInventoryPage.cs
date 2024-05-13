using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIInventoryPage : MonoBehaviour
{
    [Header("Important")]
    [SerializeField]
    private UIInventoryItem itemPrefab;
    [SerializeField]
    private UIInventoryItem itemBasePrefab;
    [SerializeField]
    private UIInventoryImage invImage;
    [SerializeField]
    private MouseFollower mouseFollower;

    [Header("Paneles")]
    [SerializeField]
    private RectTransform contentPanel;
    [SerializeField]
    private RectTransform contentBagPanel;
    [SerializeField]
    private RectTransform contentBasePanel;

    [Header("Others")]
    List<UIInventoryItem> inventoryItems = new List<UIInventoryItem>();
    public Sprite image;

    private void Awake()
    {
        Hide();
        mouseFollower.Toggle(false);
        invImage.ResetImage();
    }

    public void InitializeInvUI(int invCharSize, int invBagSize, int invBaseSize)
    {
        for (int i = 0; i < invCharSize; i++)
        {
            UIInventoryItem uiItem = Instantiate(itemPrefab, Vector3.zero, Quaternion.identity);
            uiItem.transform.SetParent(contentPanel);
            inventoryItems.Add(uiItem);

            uiItem.OnItemClicked += HandleItemSelection;
            uiItem.OnItemBeginDrag += HandleBeginDrag;
            uiItem.OnItemDroppedOn += HandleSwap;
            uiItem.OnItemEndDrag += HandleEndDrag;
            uiItem.OnRightMouseBtnClick += HandleShowItemActions;
        }

        for (int i = 0; i < invBagSize; i++)
        {
            UIInventoryItem uiItem = Instantiate(itemPrefab, Vector3.zero, Quaternion.identity);
            uiItem.transform.SetParent(contentBagPanel);
            inventoryItems.Add(uiItem);

            uiItem.OnItemClicked += HandleItemSelection;
            uiItem.OnItemBeginDrag += HandleBeginDrag;
            uiItem.OnItemDroppedOn += HandleSwap;
            uiItem.OnItemEndDrag += HandleEndDrag;
            uiItem.OnRightMouseBtnClick += HandleShowItemActions;
        }

        for (int i = 0; i < invBaseSize; i++)
        {
            UIInventoryItem uiItem = Instantiate(itemBasePrefab, Vector3.zero, Quaternion.identity);
            uiItem.transform.SetParent(contentBasePanel);
            inventoryItems.Add(uiItem);

            uiItem.OnItemClicked += HandleItemSelection;
            uiItem.OnItemBeginDrag += HandleBeginDrag;
            uiItem.OnItemDroppedOn += HandleSwap;
            uiItem.OnItemEndDrag += HandleEndDrag;
            uiItem.OnRightMouseBtnClick += HandleShowItemActions;
        }
    }

    private void HandleShowItemActions(UIInventoryItem item)
    {
        
    }

    private void HandleEndDrag(UIInventoryItem item)
    {
        mouseFollower.Toggle(false);
    }

    private void HandleSwap(UIInventoryItem item)
    {
        
    }

    private void HandleBeginDrag(UIInventoryItem item)
    {
        mouseFollower.Toggle(true);
        mouseFollower.SetData(image);
    }

    private void HandleItemSelection(UIInventoryItem item)
    {
        invImage.SetImage(image);
        inventoryItems[0].Select();
    }

    public void Show()
    {
        gameObject.SetActive(true);
        invImage.ResetImage();
        inventoryItems[0].SetData(image);
    }

    public void Hide() 
    {
        gameObject.SetActive(false);
    }
}
