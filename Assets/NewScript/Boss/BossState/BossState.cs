using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BossState
{
    public abstract void Enter(BossController boss);
    public abstract void Update(BossController boss);
    public abstract void Exit(BossController boss);
}
