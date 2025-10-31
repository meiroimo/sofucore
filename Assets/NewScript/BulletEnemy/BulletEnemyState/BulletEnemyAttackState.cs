using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletEnemyAttackState : BulletEnemyState
{
    public override void Enter(BulletEnemyController bulletEnemy)
    {
        Debug.Log("íeÇÃê∂ê¨");
        bulletEnemy.InitBullet();
        bulletEnemy.ChangeState(new BulletEnemyChaseState());
    }

    public override void Update(BulletEnemyController bulletEnemy)
    {

    }

    public override void Exit(BulletEnemyController bulletEnemy)
    {

    }
}
