using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ItemSO : ScriptableObject
{
    public int itemID;

    public Sprite itemImage;

    private static readonly string[] Rarities = { "Rare", "Epic", "Mythic", "Legendary" };

    public string RarityString;
    [DoNotSerialize] public int Rarity;

    private void OnEnable()
    {
        if (RarityString == "")
        {
            Rarity = Random.Range(0, Rarities.Length);
            RarityString = Rarities[Rarity];
        }
        
    }
    
}
