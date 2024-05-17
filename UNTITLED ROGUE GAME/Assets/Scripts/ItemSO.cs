using System;
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

    [DoNotSerialize] public List<ItemParameter> DefaultParametersList { get; set; }

    private void OnEnable()
    {
        if (RarityString == "")
        {
            Rarity = UnityEngine.Random.Range(0, Rarities.Length);
            RarityString = Rarities[Rarity];
        }
        
    }
    
}
[Serializable]
public struct ItemParameter : IEquatable<ItemParameter>
{
    public ItemParameterSO itemParameter;
    public float value;

    public bool Equals(ItemParameter other)
    {
        return other.itemParameter == itemParameter;
    }
}
