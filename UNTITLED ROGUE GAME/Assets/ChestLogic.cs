using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using UnityEngine;

public class ChestLogic : MonoBehaviour
{
    private LevelLogic _levelLogic;

    // Start is called before the first frame update
    void Start()
    {
        _levelLogic = GameObject.Find("Level").GetComponent<LevelLogic>();
        _levelLogic.OnEnemiesKilled += ActivateChest;
    }

    public void ActivateChest(object sender, EventArgs e )
    {
        gameObject.GetComponent<SpriteRenderer>().enabled = true;
        gameObject.GetComponent<BoxCollider2D>().enabled = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ( collision.CompareTag("Player"))
        {
            //animacion para abrir cofre e instanciacion del item recogible/ pantalla de item obtenido 
        }
    }
}
