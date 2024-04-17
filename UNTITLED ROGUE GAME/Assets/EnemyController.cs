using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : EnemyStateController, IDamageable
{
    public float HP;
    public float AttackDistance;

    // Update is called once per frame
    void Update()
    {
        StateTransition();
        if (currentState.action != null) currentState.action.OnUpdate();
    }
    public void OnHurt(float damage)
    {
        HP -= damage;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        target = GameObject.Find("Player");
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        target = null;
    }
}
