using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "ScriptableAttack", menuName =
    "ScriptableObjects2/ScriptableAction/ScriptableAttack", order = 1)]
public class ScriptableAttack : ScriptableAction
{
    public Animator animator;
    public EnemyController enemyController;

    public override void OnFinishedState()
    {
        //GameManager.gm.UpdateText("va te perdono");
        animator.Play("Movement");
    }

    public override void OnSetState(EnemyStateController sc)
    {
        base.OnSetState(sc);
        animator = sc.GetComponent<Animator>();
        enemyController = sc.GetComponent<EnemyController>();
        animator.Play("Attack");
        if (enemyController.bulletPrefab != null) enemyController.LaunchBullet();
        else
        {
            var sword = enemyController.sword.GetComponent<RotateSword>();
            sword.Attack();
        }
        //GameManager.gm.UpdateText("a q te meto");
    }
    
    public override void OnUpdate()
    {
       // GameManager.gm.UpdateText("que te meto asin");
    }
}
