using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BulletEnemyState
{
    public abstract void Enter(BulletEnemyController bulletEnemy);
    public abstract void Update(BulletEnemyController bulletEnemy);
    public abstract void Exit(BulletEnemyController bulletEnemy);
}
