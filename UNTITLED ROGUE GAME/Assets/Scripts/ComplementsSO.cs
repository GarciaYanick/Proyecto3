using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Equipment", menuName = "Complements")]
public class ComplementsSO : ItemSO
{

    public float statMultiplier;

    public string[] stats = { "health", "armor" };

    public string multiplier;

    private void OnEnable()
    {
        multiplier = stats[Random.Range(0, stats.Length)];
        switch (Rarity)
        {
            case "Rare":
                statMultiplier = 1.10f;
                break;
            case "Epic":
                statMultiplier = 1.20f;
                break;
            case "Mythic":
                statMultiplier = 1.30f;
                break;
            case "Legendary":
                statMultiplier = 1.40f;
                break;
            default:
                statMultiplier = 1;
                break;
        }
    }

}
