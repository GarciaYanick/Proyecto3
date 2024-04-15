using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Target", menuName = "ScriptableNodes/ScriptableConditions/Target")]
public class CheckTarget : ScriptableCondition
{
    public override bool Check(BossStateController sc)
    {
        return sc.target != null;
    }
}
