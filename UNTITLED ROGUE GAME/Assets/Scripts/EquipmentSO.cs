using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Equipment", menuName = "Armors")]
public class EquipmentSO : ItemSO
{
    public int armor;

    private void OnEnable()
    {
        if (armor == 0)
        {
            switch (Rarity)
            {
                case "Rare":
                    armor = Random.Range(1, 3);
                    break;
                case "Epic":
                    armor = Random.Range(4, 6);
                    break;
                case "Mythic":
                    armor = Random.Range(6, 8);
                    break;
                case "Legendary":
                    armor = Random.Range(8, 10);
                    break;
                default:
                    armor = 5;
                    break;
            }
        }
    }
}
