using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using UnityEngine;

public class ChestLogic : MonoBehaviour
{
    private LevelLogic _levelLogic;
    private Animator _anim;

    // Start is called before the first frame update
    void Start()
    {
        _levelLogic = GameObject.FindWithTag("Level").GetComponent<LevelLogic>();
        _levelLogic.OnEnemiesKilled += ActivateChest;
        _anim = gameObject.GetComponent<Animator>();
    }

    public void ActivateChest(object sender, EventArgs e )
    {
        gameObject.GetComponent<SpriteRenderer>().enabled = true;
        gameObject.GetComponent<BoxCollider2D>().enabled = true;
        _anim.enabled = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ( collision.CompareTag("Player"))
        {
            //animacion para abrir cofre e instanciacion del item recogible/ pantalla de item obtenido 
            _anim.SetBool( "OpenChest", true );
        }
    }
}
