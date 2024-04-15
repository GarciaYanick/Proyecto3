using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ScriptableAction : ScriptableObject
{
    protected BossStateController sc;
    public abstract void OnFinishedState();

    public virtual void OnSetState(BossStateController sc) {
        this.sc = sc;
    }

    public abstract void OnUpdate();
}
