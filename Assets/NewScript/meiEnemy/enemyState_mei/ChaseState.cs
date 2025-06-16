using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseState : EnemyState
{
    public override void Enter(EnemyController enemy) { }

    public override void Update(EnemyController enemy)
    {
        // プレイヤーの位置に向かって移動
        enemy.Agent.SetDestination(enemy.player.position);

        // 攻撃範囲に入ったら攻撃状態へ
        if (enemy.IsPlayerInAttackRange())
        {
            enemy.ChangeState(new AttackState());
        }
    }

    public override void Exit(EnemyController enemy) { }
}
