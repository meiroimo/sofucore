using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletEnemyChaseState : BulletEnemyState
{
    private float attackCounter;

    public override void Enter(BulletEnemyController bulletEnemy)
    {
        Debug.Log("’e”­ŽË‘Ò‹@");
        attackCounter = 0;
        bulletEnemy.AttackInterval = 4f;
    }

    public override void Update(BulletEnemyController bulletEnemy)
    {
        attackCounter += Time.deltaTime;
        if(attackCounter > bulletEnemy.AttackInterval)
        {
            bulletEnemy.ChangeState(new BulletEnemyAttackState());
        }
    }

    public override void Exit(BulletEnemyController bulletEnemy)
    {
        attackCounter = 0;
    }
}
