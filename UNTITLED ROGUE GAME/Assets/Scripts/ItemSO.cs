using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ItemSO : ScriptableObject
{
    public int itemID;

    public Sprite itemImage;

    private static readonly string[] Rarities = { "Rare", "Epic", "Mythic", "Legendary" };

    public string Rarity;
     
    

    private void OnEnable()
    {
        if (Rarity == null)
        {
            int rnd = Random.Range(0, Rarities.Length);

            Rarity = Rarities[rnd];
        }
        
    }
    
}
