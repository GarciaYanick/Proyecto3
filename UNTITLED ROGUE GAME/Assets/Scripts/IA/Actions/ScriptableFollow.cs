using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "ScriptableFollow", menuName = "ScriptableObjects2/ScriptableAction/ScriptableFollow")]

public class ScriptableFollow : ScriptableAction
{
    private BossMovement _chaseBehaviour;
    private BossController _enemyController;
    public override void OnFinishedState()
    {
        _chaseBehaviour.StopChasing();
    }

    public override void OnSetState(BossStateController sc)
    {
        base.OnSetState(sc);
        //GameManager.gm.UpdateText("Te persigo");
        _chaseBehaviour = sc.GetComponent<BossMovement>();
        _enemyController = (BossController)sc;
    }

    public override void OnUpdate()
    {
        _chaseBehaviour.Chase(_enemyController.target.transform, sc.transform);
    }
}
