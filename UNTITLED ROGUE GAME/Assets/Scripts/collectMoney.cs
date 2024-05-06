using System.Collections;
using System.Collections.Generic;
using TopDownCharacter2D.Stats;
using UnityEngine;

public class collectMoney : MonoBehaviour
{
    public CharacterStatsHandler statsHandler;
    // Start is called before the first frame update
    private void Start()
    {
        statsHandler.GetComponent<CharacterStatsHandler>();
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
       if (collision.CompareTag("coin"))
       {
            statsHandler.money++;
       }
    }
}
