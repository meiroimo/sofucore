using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyState
{
    public abstract void Enter(EnemyController enemy);
    public abstract void Update(EnemyController enemy);
    public abstract void Exit(EnemyController enemy);
}
