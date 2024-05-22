using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    [SerializeField]
    private InventarySO inventoryData;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Mira lo pillaste");

        Item item = collision.GetComponent<Item>();
        if(item != null )
        {
            int reminder = inventoryData.AddItem(item.inventoryItem, item.quantity);

            if(reminder == 0)
            {
                item.DestroyItem();
            }

            else
            {
                item.quantity = reminder;
            }
        }
    }
}
