using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletEnemyChaseState : BulletEnemyState
{
    private float attackCounter;

    public override void Enter(BulletEnemyController bulletEnemy)
    {
        Debug.Log("弾発射待機");
        attackCounter = 0;
        bulletEnemy.AttackInterval = 4f;
    }

    public override void Update(BulletEnemyController bulletEnemy)
    {
        // プレイヤーの位置に向かって移動
        bulletEnemy.Agent.SetDestination(bulletEnemy.player.position);


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
