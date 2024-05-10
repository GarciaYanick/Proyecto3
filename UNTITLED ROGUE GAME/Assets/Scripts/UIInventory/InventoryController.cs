using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    [SerializeField]
    private UIInventoryPage inventoryUI;

    public int invCharSize;

    public int invBagSize;

    public int invBaseSize;

    private void Start()
    {
        inventoryUI.InitializeInvUI(invCharSize, invBagSize, invBaseSize);       
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
