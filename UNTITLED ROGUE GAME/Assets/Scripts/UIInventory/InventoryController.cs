using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    [SerializeField]
    private UIInventoryPage inventoryUI;

    public int invSize = 80;

    private void Start()
    {
        inventoryUI.InitializeInvUI(invSize);       
    }

    private void Update()
    {
       if (Input.GetKeyUp(KeyCode.I))
        {
            if(inventoryUI.isActiveAndEnabled == false)
            {
                inventoryUI.Show();
            }
            else
            {
                inventoryUI.Hide();
            }
        }
    }
}
